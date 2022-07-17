using System.ComponentModel.DataAnnotations;

namespace Happet.Models
{
    public enum ETypePet
    {
        [Display(Name = "Gato")]
        Cat = 1,

        [Display(Name = "Cachorro")]
        Dog = 2
    }
}
