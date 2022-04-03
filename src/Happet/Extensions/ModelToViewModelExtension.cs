using Happet.Models;
using Happet.ViewModel;

namespace Happet.Extensions
{
    public static class ModelToViewModelExtension
    {
        public static EditAdopterViewModel ToViewModel(this Adopter adopter)
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

        public static EditNgoViewModel ToViewModel(this Ngo ngo)
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
    }
}
