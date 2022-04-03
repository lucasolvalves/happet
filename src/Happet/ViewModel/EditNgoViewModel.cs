using System;
using System.ComponentModel.DataAnnotations;

namespace Happet.ViewModel
{
    public record EditNgoViewModel : EditPeopleViewModel
    {
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string FantasyName { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CNPJ { get; set; }
    }
}