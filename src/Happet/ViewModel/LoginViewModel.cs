using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public record LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(256, ErrorMessage = "O campo {0} não pode exceder {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
