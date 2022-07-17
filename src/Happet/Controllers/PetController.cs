using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Happet.ViewModel;
using Happet.Models;
using Happet.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using Happet.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Happet.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IPetRepository _petRepository;
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IVaccineCardRepository _vaccineCardRepository;
        private long _SIZEMAXFILE = 2097152; //2MB

        public PetController(UserManager<IdentityUser> userManager, IAccountRepository accountRepository, IPetRepository petRepository,
            IVaccineRepository vaccineRepository, IVaccineCardRepository vaccineCardRepository)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
            _petRepository = petRepository;
            _vaccineRepository = vaccineRepository;
            _vaccineCardRepository = vaccineCardRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var pets = await GetPetsByUserId();

            return View(pets);
        }

        [Authorize(Policy = "Ngo")]
        public IActionResult Create()
        {
            var registerPetViewModel = new RegisterPetViewModel
            {
                Vaccines = _vaccineRepository.GetVaccines().ToViewModel()
            };

            return View(registerPetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterPetViewModel registerPetViewModel)
        {
            var fileViewModel = await GetFileBytesAsync(registerPetViewModel.Image);
            registerPetViewModel.ImageBytes = fileViewModel?.Bytes;
            registerPetViewModel.ImageDescription = fileViewModel?.Description;

            var vaccines = new List<VaccineViewModel>();
            _vaccineRepository.GetVaccines().ToViewModel().ToList().ForEach(vaccine =>
                {
                    registerPetViewModel.AppliedVaccines.ToList().ForEach(idVaccine =>
                    {
                        if (vaccine.Id.ToString() == idVaccine)
                            vaccine.Checked = true;
                    });
                    vaccines.Add(vaccine);
                }
            );

            registerPetViewModel.Vaccines = vaccines;

            if (!ModelState.IsValid)
                return View(registerPetViewModel);

            var people = await GetPeopleByUserIdAsync();
            registerPetViewModel.IdPeople = people.Id;

            if (registerPetViewModel.AppliedVaccines.Any())
                registerPetViewModel.IdVaccineCard = await CreateVaccineCard(registerPetViewModel.AppliedVaccines);

            await _petRepository.AddPetAsync(registerPetViewModel.ToRegisterModel());

            return RedirectToAction("Index");
        }

        [Authorize(Policy = "Ngo")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var pet = await _petRepository.GetPetByIdAsync(id);

            var vaccines = new List<VaccineViewModel>();
            _vaccineRepository.GetVaccines().ToViewModel().ToList().ForEach(vaccine =>
            {
                pet.VaccineCard?.VacineCardItems.ToList().ForEach(vacineCardItem =>
                {
                    if (vacineCardItem.IdVaccine == vaccine.Id)
                        vaccine.Checked = true;
                });
                vaccines.Add(vaccine);
            }
            );

            var editPetViewModel = pet.ToViewModelEdit();
            editPetViewModel.Vaccines = vaccines;

            return View(editPetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPetViewModel editPetViewModel)
        {
            var fileViewModel = await GetFileBytesAsync(editPetViewModel.Image);

            if (!ModelState.IsValid)
                return View(editPetViewModel);

            var pet = await _petRepository.GetPetByIdAsync(editPetViewModel.Id);

            pet.Name = editPetViewModel.Name;
            pet.Breed = editPetViewModel.Breed;
            pet.Color = editPetViewModel.Color;
            pet.Age = editPetViewModel.Age;
            pet.Weight = editPetViewModel.Weight;
            pet.TypeGender = editPetViewModel.TypeGender;
            pet.Castrated = editPetViewModel.Castrated;
            pet.Location = editPetViewModel.Location;
            pet.TypePet = editPetViewModel.TypePet.Value;
            pet.Observation = editPetViewModel.Observation;

            if (fileViewModel?.Bytes is not null)
            {
                pet.ImageBytes = fileViewModel.Bytes;
                pet.ImageDescription = fileViewModel.Description;
            }

            if (pet.IdVaccineCard.HasValue)
            {
                var newIdVaccines = editPetViewModel?.AppliedVaccines.Except(pet.VaccineCard?.VacineCardItems.Select(x => x.IdVaccine.ToString()));
                var newVacineCardItems = pet.VaccineCard.VacineCardItems.ToList();

                if (newIdVaccines.Any())
                {
                    newVacineCardItems.AddRange(newIdVaccines.Select(idVaccine => new VacineCardItem()
                    {
                        IdVaccineCard = pet.IdVaccineCard.Value,
                        IdVaccine = Guid.Parse(idVaccine),
                        ApplicationDate = DateTime.Now
                    }));
                }
                else
                {
                    var removeIdVaccines = pet.VaccineCard?.VacineCardItems.Select(x => x.IdVaccine.ToString()).Except(editPetViewModel?.AppliedVaccines).ToList();

                    pet.VaccineCard.VacineCardItems.ToList().ForEach(vacineCardItem =>
                    {
                        removeIdVaccines.ForEach(idVaccine =>
                        {
                            if (vacineCardItem.IdVaccine.ToString() == idVaccine)
                                newVacineCardItems.Remove(vacineCardItem);
                        });
                    });
                }

                pet.VaccineCard.VacineCardItems = newVacineCardItems;

                if (!newVacineCardItems.Any())
                    await _vaccineCardRepository.DeleteVaccineCardAsync(pet.VaccineCard);
            }
            else
                pet.IdVaccineCard = await CreateVaccineCard(editPetViewModel.AppliedVaccines);

            await _petRepository.UpdatePetAsync(pet);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var pet = await _petRepository.GetPetByIdAsync(id);
            var detailViewModel = pet.ToViewModel();

            var people = await GetPeopleByUserIdAsync();

            if (people is null || people?.TypePeople == ETypePeople.Adopter)
                detailViewModel.EnableToAdopt = true;

            return View(detailViewModel);
        }

        [Authorize(Policy = "Ngo")]
        public IActionResult Delete(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var pet = await _petRepository.GetPetByIdAsync(id);

            if (pet.Donations.Any())
            {
                pet.Status = EStatusPet.Disabled;
                await _petRepository.UpdatePetAsync(pet);
            }
            else
            {
                await _vaccineCardRepository.DeleteVaccineCardAsync(pet.VaccineCard);
                await _petRepository.DeletePetAsync(pet);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Term(Guid id)
        {
            var people = await GetPeopleByUserIdAsync();
            var identityUser = await _userManager.FindByIdAsync(people.UserId);
            var adopter = await _accountRepository.GetAdopterByPeopleIdAsync(people.Id);
            var pet = await _petRepository.GetPetByIdAsync(id);

            var termViewModel = new TermViewModel()
            {
                IdPeople = people.Id,
                FullName = adopter.FullName,
                Address = people.Address,
                District = people.District,
                City = people.City,
                State = people.State,
                CEP = people.CEP,
                BirthDate = adopter.BirthDate,
                CPF = adopter.CPF,
                RG = adopter.RG,
                CellPhone = people.CellPhone,
                OccupationArea = people.OccupationArea,
                Email = identityUser.Email,
                IdPet = pet.Id,
                PetName = pet.Name,
                Breed = pet.Breed,
                TypePet = pet.TypePet,
                Weight = pet.Weight,
                Age = pet.Age,
                TypeGender = pet.TypeGender,
                Color = pet.Color,
                Vaccines = pet.VaccineCard?.VacineCardItems?.Select(x => x.Vaccine.Description),
                Castrated = pet.Castrated,
                Observation = pet.Observation,
                PetLocation = pet.Location
            };


            return View(termViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToAdopt(bool agreeTerm, Guid idPeople, Guid idPet)
        {
            if (agreeTerm)
            {
                var adopt = new Adopt()
                {
                    IdPet = idPet,
                    IdPeople = idPeople,
                    AdoptionTerm = true,
                    Status = EStatusAdopt.Adopted,
                    CreateDate = DateTime.Now
                };

                var pet = await _petRepository.GetPetByIdAsync(idPet);
                pet.Status = EStatusPet.Adopted;

                await _petRepository.ToAdoptAsync(adopt);
                await _petRepository.UpdatePetAsync(pet);
                ViewBag.TermIsRequired = false;
            }
            else
            {
                TempData["term-is-required"] = true;
                return RedirectToAction("Term", new { id = idPet });
            }

            return RedirectToAction("Index", "Pet");
        }

        public async Task<IActionResult> DetailsAdopterPet(Guid idAdopter)
        {
            var adopter = await _accountRepository.GetAdopterByPeopleIdAsync(idAdopter);
            var identityUser = await _userManager.FindByIdAsync(adopter.People.UserId);

            var detailsAdopterPetViewModel = new DetailsAdopterPetViewModel()
            {
                FullName = adopter.FullName,
                OccupationArea = adopter.People.OccupationArea,
                CellPhone = adopter.People.CellPhone,
                Address = adopter.People.Address,
                District = adopter.People.District,
                City = adopter.People.City,
                State = adopter.People.State,
                CEP = adopter.People.CEP,
                Email = identityUser.Email
            };

            return View(detailsAdopterPetViewModel);
        }

        private async Task<IEnumerable<GridPetViewModel>> GetPetsByUserId()
        {
            var people = await GetPeopleByUserIdAsync();
            IEnumerable<Pet> pets = new List<Pet>();

            if (people.TypePeople == ETypePeople.Ngo)
                pets = _petRepository.GetPetsByIdPeople(people.Id);
            else
                pets = _petRepository.GetAdoptedPetsByIdPeople(people.Id);

            var gridPetViewModel = new List<GridPetViewModel>();

            foreach (var pet in pets)
            {
                gridPetViewModel.Add(new GridPetViewModel()
                {
                    IdPet = pet.Id,
                    Name = pet.Name,
                    Breed = pet.Breed,
                    Color = pet.Color,
                    Type = pet.TypePet,
                    Genre = pet.TypeGender,
                    Status = pet.Status,
                    CreateDate = pet.CreateDate,
                    IdAdopter = pet.Adoptions?.FirstOrDefault(x => x.Status == EStatusAdopt.Adopted)?.IdPeople
                });
            }

            return gridPetViewModel;
        }

        private async Task<FileViewModel> GetFileBytesAsync(IFormFile file)
        {
            if (file?.Length == 0 || file is null)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                if (memoryStream.Length < _SIZEMAXFILE)
                {
                    return new FileViewModel()
                    {
                        Bytes = memoryStream.ToArray(),
                        Description = file.FileName
                    };
                }
                else
                {
                    ModelState.AddModelError("Image", "O arquivo é superior a 2MB.");
                    return null;
                }
            }
        }

        private async Task<People> GetPeopleByUserIdAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return null;

            return await _accountRepository.GetPeopleByUserIdAsync(userId);
        }

        private VaccineCard GenerateVaccineCard(IEnumerable<string> appliedVaccines)
        {
            var idVaccineCard = Guid.NewGuid();
            var applicationDate = DateTime.Now;

            var vaccineCardItem = appliedVaccines.Select(idVaccine =>
            new VacineCardItem()
            {
                Id = Guid.NewGuid(),
                IdVaccineCard = idVaccineCard,
                IdVaccine = Guid.Parse(idVaccine),
                ApplicationDate = applicationDate

            });

            return new VaccineCard()
            {
                Id = idVaccineCard,
                CreateDate = DateTime.Now,
                VacineCardItems = vaccineCardItem.ToList(),
            };
        }

        private async Task<Guid> CreateVaccineCard(IEnumerable<string> appliedVaccines)
        {
            var vacineCard = GenerateVaccineCard(appliedVaccines);
            await _vaccineCardRepository.AddVaccineCardAsync(vacineCard);
            return vacineCard.Id;
        }
    }
}
