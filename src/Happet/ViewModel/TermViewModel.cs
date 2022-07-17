using Happet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class TermViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid IdPeople { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CellPhone { get; set; }
        public string OccupationArea { get; set; }
        public string Email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid IdPet { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public ETypePet TypePet { get; set; }
        public float? Weight { get; set; }
        public int? Age { get; set; }
        public ETypeGender TypeGender { get; set; }
        public string Color { get; set; }
        public IEnumerable<string> Vaccines { get; set; }
        public bool Castrated { get; set; }
        public string Observation { get; set; }
        public string PetLocation { get; set; }
    }
}
