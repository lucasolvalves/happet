using Happet.Models;
using Happet.ViewModel;

namespace Happet.Extensions
{
    public static class RegisterViewModelExtension
    {
        public static Adopter ToAdopter(this RegisterAdopterViewModel registerAdopterViewModel)
        {
            return new Adopter()
            {
                People = new People()
                {
                    Id = registerAdopterViewModel.Id,
                    UserId = registerAdopterViewModel.UserId,
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

        public static Ngo ToNgo(this RegisterNgoViewModel registerNgoViewModel)
        {
            return new Ngo()
            {
                People = new People()
                {
                    Id = registerNgoViewModel.Id,
                    UserId = registerNgoViewModel.UserId,
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
    }
}
