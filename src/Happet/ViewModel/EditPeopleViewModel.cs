using Happet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Happet.ViewModel
{
    public record EditPeopleViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public ETypePeople TypePeople { get; set; }

        [Display(Name = "Área de Atuação")]
        [StringLength(50, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string OccupationArea { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CellPhone { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string District { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string State { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(8, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string CEP { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(256, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Senha atual")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "Nova Senha")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
