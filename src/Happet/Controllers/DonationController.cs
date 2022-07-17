using Happet.Extensions;
using Happet.Interfaces;
using Happet.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Happet.Controllers
{
    [Authorize]
    public class DonationController : Controller
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IAccountRepository _accountRepository;

        public DonationController(IDonationRepository donationRepository, IAccountRepository accountRepository)
        {
            _donationRepository = donationRepository;
            _accountRepository = accountRepository;
        }

        [Authorize(Policy = "Ngo")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var people = await _accountRepository.GetPeopleByUserIdAsync(userId);

            var donations = _donationRepository.GetDonationsByNgo(people.Id);

            var gridDonationViewModel = donations?.Select(x => new GridDonationViewModel()
            {
                Id = x.Id,
                PetName = x.Pet.Name,
                Value = x.Value,
                PaymentDate = x.PaymentDate
            });

            return View(gridDonationViewModel);
        }

        [AllowAnonymous]
        public IActionResult GiveAway(Guid idPet)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GiveAwayAsync(RegisterGiveAwayViewModel registerGiveAwayViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerGiveAwayViewModel);

            await _donationRepository.AddDonationAsync(registerGiveAwayViewModel.ToRegisterModel());

            return RedirectToAction("Index", "Home");
        }
    }
}
