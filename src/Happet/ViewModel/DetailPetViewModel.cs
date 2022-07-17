using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class DetailPetViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public ETypeGender TypeGender { get; set; }
        public bool Castrated { get; set; }
        public string Location { get; set; }
        public IEnumerable<Vaccine> Vaccines { get; set; }
        public ETypePet TypePet { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Observation { get; set; }
        public EStatusPet Status { get; set; }
        public bool EnableToAdopt { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
