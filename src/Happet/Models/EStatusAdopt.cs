using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    public enum EStatusAdopt
    {
        [Display(Name = "Adotada(o)")]
        Adopted = 1,

        [Display(Name = "Desistiu")]
        Giveup = 2
    }
}
