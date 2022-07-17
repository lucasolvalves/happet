using Happet.Models;
using System;

namespace Happet.ViewModel
{
    public record GridPetViewModel
    {
        public Guid IdPet { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public ETypePet Type { get; set; }
        public ETypeGender Genre { get; set; }
        public EStatusPet Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? IdAdopter { get; set; }
    }
}
