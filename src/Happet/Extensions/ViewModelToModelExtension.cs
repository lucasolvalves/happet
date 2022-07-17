using Happet.Models;
using Happet.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Happet.Extensions
{
    public static class ViewModelToModelExtension
    {
        public static Adopter ToRegisterModel(this RegisterAdopterViewModel registerAdopterViewModel)
        {
            return new Adopter()
            {
                People = new People()
                {
                    Id = registerAdopterViewModel.Id,
                    UserId = registerAdopterViewModel.UserId,
                    TypePeople = ETypePeople.Adopter,
                    OccupationArea = registerAdopterViewModel.OccupationArea,
                    CellPhone = registerAdopterViewModel.CellPhone,
                    Address = registerAdopterViewModel.Address,
                    District = registerAdopterViewModel.District,
                    City = registerAdopterViewModel.City,
                    State = registerAdopterViewModel.State,
                    CEP = registerAdopterViewModel.CEP,
                    CreateDate = registerAdopterViewModel.CreateDate
                },
                IdPeople = registerAdopterViewModel.Id,
                FullName = registerAdopterViewModel.FullName,
                RG = registerAdopterViewModel.RG,
                CPF = registerAdopterViewModel.CPF,
                BirthDate = registerAdopterViewModel.BirthDate.Value
            };
        }

        public static Ngo ToRegisterModel(this RegisterNgoViewModel registerNgoViewModel)
        {
            return new Ngo()
            {
                People = new People()
                {
                    Id = registerNgoViewModel.Id,
                    UserId = registerNgoViewModel.UserId,
                    TypePeople = ETypePeople.Ngo,
                    OccupationArea = registerNgoViewModel.OccupationArea,
                    CellPhone = registerNgoViewModel.CellPhone,
                    Address = registerNgoViewModel.Address,
                    District = registerNgoViewModel.District,
                    City = registerNgoViewModel.City,
                    State = registerNgoViewModel.State,
                    CEP = registerNgoViewModel.CEP,
                    CreateDate = registerNgoViewModel.CreateDate
                },
                IdPeople = registerNgoViewModel.Id,
                FantasyName = registerNgoViewModel.FantasyName,
                CNPJ = registerNgoViewModel.CNPJ
            };
        }

        public static Adopter ToEditModel(this EditAdopterViewModel editAdopterViewModel)
        {
            return new Adopter()
            {
                People = new People()
                {
                    Id = editAdopterViewModel.Id,
                    UserId = editAdopterViewModel.UserId,
                    TypePeople = ETypePeople.Adopter,
                    OccupationArea = editAdopterViewModel.OccupationArea,
                    CellPhone = editAdopterViewModel.CellPhone,
                    Address = editAdopterViewModel.Address,
                    District = editAdopterViewModel.District,
                    City = editAdopterViewModel.City,
                    State = editAdopterViewModel.State,
                    CEP = editAdopterViewModel.CEP,
                    CreateDate = editAdopterViewModel.CreateDate
                },
                IdPeople = editAdopterViewModel.Id,
                FullName = editAdopterViewModel.FullName,
                RG = editAdopterViewModel.RG,
                CPF = editAdopterViewModel.CPF,
                BirthDate = editAdopterViewModel.BirthDate.Value
            };
        }

        public static Ngo ToEditModel(this EditNgoViewModel editNgoViewModel)
        {
            return new Ngo()
            {
                People = new People()
                {
                    Id = editNgoViewModel.Id,
                    UserId = editNgoViewModel.UserId,
                    TypePeople = ETypePeople.Ngo,
                    OccupationArea = editNgoViewModel.OccupationArea,
                    CellPhone = editNgoViewModel.CellPhone,
                    Address = editNgoViewModel.Address,
                    District = editNgoViewModel.District,
                    City = editNgoViewModel.City,
                    State = editNgoViewModel.State,
                    CEP = editNgoViewModel.CEP,
                    CreateDate = editNgoViewModel.CreateDate
                },
                IdPeople = editNgoViewModel.Id,
                FantasyName = editNgoViewModel.FantasyName,
                CNPJ = editNgoViewModel.CNPJ
            };
        }

        public static Pet ToRegisterModel(this RegisterPetViewModel registerPetViewModel)
        {
            return new Pet()
            {
                Id = registerPetViewModel.Id,
                IdPeople = registerPetViewModel.IdPeople,
                Name = registerPetViewModel.Name,
                Breed = registerPetViewModel.Breed,
                Color = registerPetViewModel.Color,
                Age = registerPetViewModel.Age,
                Weight = registerPetViewModel.Weight,
                TypeGender = registerPetViewModel.TypeGender,
                Castrated = registerPetViewModel.Castrated,
                IdVaccineCard = registerPetViewModel.IdVaccineCard,
                Location = registerPetViewModel.Location,
                TypePet = registerPetViewModel.TypePet.Value,
                ImageBytes = registerPetViewModel.ImageBytes,
                ImageDescription = registerPetViewModel.ImageDescription,
                Observation = registerPetViewModel.Observation,
                Status = registerPetViewModel.Status,
                CreateDate = registerPetViewModel.CreateDate
            };
        }

        public static Donation ToRegisterModel(this RegisterGiveAwayViewModel registerGiveAwayViewModel)
        {
            return new Donation()
            {
                Id = registerGiveAwayViewModel.Id,
                IdPet = registerGiveAwayViewModel.IdPet,
                FullName = registerGiveAwayViewModel.FullName,
                CellPhone = registerGiveAwayViewModel.CellPhone,
                Address = registerGiveAwayViewModel.Address,
                District = registerGiveAwayViewModel.District,
                City = registerGiveAwayViewModel.City,
                State = registerGiveAwayViewModel.State,
                CEP = registerGiveAwayViewModel.CEP,
                Email = registerGiveAwayViewModel.Email,
                Value = registerGiveAwayViewModel.Value.Value,
                Status = EStatusDonation.Approved,
                PaymentDate = registerGiveAwayViewModel.PaymentDate
            };
        }
    }
}
