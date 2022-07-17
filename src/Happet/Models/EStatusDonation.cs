using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    public enum EStatusDonation
    {
        [Display(Name = "Aprovado")]
        Approved = 1,

        [Display(Name = "Rejeitado")]
        Rejected = 2
    }
}
