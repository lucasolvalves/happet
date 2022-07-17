using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class RegisterGiveAwayViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [HiddenInput(DisplayValue = false)]
        public Guid IdPet { get; set; }

        [Display(Name = "Nome do titular")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string FullName { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CellPhone { get; set; }

        [Display(Name = "Número do cartão de crédito")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public long? CreditCardNumber { get; set; }

        [Display(Name = "Valido até")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public int? CreditCardExpirationMonth { get; set; }

        [Display(Name = "Valido até")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public int? CreditCardExpirationYear { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public int? CVV { get; set; }

        [Display(Name = "Endereço de cobrança")]
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
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(256, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "O {0} deve ser superior a R${1}.")]
        public float? Value { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
