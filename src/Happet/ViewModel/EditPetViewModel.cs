using Happet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class EditPetViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public Guid IdPeople { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Raça")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string Breed { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string Color { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public ETypeGender TypeGender { get; set; }

        [Display(Name = "Castrado")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public bool Castrated { get; set; }

        public Guid? IdVaccineCard { get; set; }
        public IEnumerable<VaccineViewModel> Vaccines { get; set; }
        public IEnumerable<string> AppliedVaccines { get; set; } = new List<string>();

        [Display(Name = "Localidade")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string Location { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public ETypePet? TypePet { get; set; }

        public IFormFile Image { get; set; }
        public string Observation { get; set; }
        public EStatusPet Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
