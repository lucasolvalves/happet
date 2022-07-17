using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    public enum ETypeGender
    {
        [Display(Name = "Macho")]
        Male = 1,

        [Display(Name = "Fêmea")]
        Female = 2
    }
}
