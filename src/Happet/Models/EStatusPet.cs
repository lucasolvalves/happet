using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    public enum EStatusPet
    {
        [Display(Name = "Inativo")]
        Disabled = 0,

        [Display(Name = "Ativo")]
        Activated = 1,

        [Display(Name = "Adotada(o)")]
        Adopted = 3
    }
}
