using System;
using System.ComponentModel.DataAnnotations;

namespace Happet.ViewModel
{
    public record RegisterAdopterViewModel : RegisterViewModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string FullName { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string RG { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}