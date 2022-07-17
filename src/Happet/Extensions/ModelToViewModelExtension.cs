using Happet.Models;
using Happet.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Happet.Extensions
{
    public static class ModelToViewModelExtension
    {
        public static EditAdopterViewModel ToViewModelEdit(this Adopter adopter)
        {
            return new EditAdopterViewModel()
            {
                Id = adopter.People.Id,
                UserId = adopter.People.UserId,
                TypePeople = adopter.People.TypePeople,
                OccupationArea = adopter.People.OccupationArea,
                CellPhone = adopter.People.CellPhone,
                Address = adopter.People.Address,
                District = adopter.People.District,
                City = adopter.People.City,
                State = adopter.People.State,
                CEP = adopter.People.CEP,
                Email = adopter.People.IdentityUser.Email,
                CreateDate = adopter.People.CreateDate,
                FullName = adopter.FullName,
                RG = adopter.RG,
                CPF = adopter.CPF,
                BirthDate = adopter.BirthDate
            };
        }

        public static EditNgoViewModel ToViewModelEdit(this Ngo ngo)
        {
            return new EditNgoViewModel()
            {
                Id = ngo.People.Id,
                UserId = ngo.People.UserId,
                TypePeople = ngo.People.TypePeople,
                OccupationArea = ngo.People.OccupationArea,
                CellPhone = ngo.People.CellPhone,
                Address = ngo.People.Address,
                District = ngo.People.District,
                City = ngo.People.City,
                State = ngo.People.State,
                CEP = ngo.People.CEP,
                Email = ngo.People.IdentityUser.Email,
                CreateDate = ngo.People.CreateDate,
                FantasyName = ngo.FantasyName,
                CNPJ = ngo.CNPJ
            };
        }

        public static EditPetViewModel ToViewModelEdit(this Pet pet)
        {
            return new EditPetViewModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Breed = pet.Breed,
                Color = pet.Color,
                Age = pet.Age,
                Weight = pet.Weight,
                TypeGender = pet.TypeGender,
                Castrated = pet.Castrated,
                Location = pet.Location,
                IdVaccineCard = pet.IdVaccineCard,
                TypePet = pet.TypePet,
                Observation = pet.Observation,
                Status = pet.Status
            };
        }

        public static DetailPetViewModel ToViewModel(this Pet pet)
        {
            return new DetailPetViewModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Breed = pet.Breed,
                Color = pet.Color,
                Age = pet.Age,
                Weight = pet.Weight,
                TypeGender = pet.TypeGender,
                Castrated = pet.Castrated,
                Location = pet.Location,
                Vaccines = pet.VaccineCard?.VacineCardItems.Select(x => x.Vaccine),
                TypePet = pet.TypePet,
                ImageBytes = pet.ImageBytes,
                Observation = pet.Observation,
                Status = pet.Status,
                CreateDate = pet.CreateDate
            };
        }

        public static IEnumerable<VaccineViewModel> ToViewModel(this IEnumerable<Vaccine> vaccines)
        {
            return vaccines.Select(vaccine =>
            new VaccineViewModel()
            {
                Id = vaccine.Id,
                Description = vaccine.Description,
                Checked = false
            });
        }
    }
}
