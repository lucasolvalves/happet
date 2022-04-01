using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happet.Models
{
    [Table("Adopters")]
    public class Adopter
    {
        [Key]
        [ForeignKey("People")]
        [Column(Order = 1)]
        public Guid IdPeople { get; set; }
        public virtual People People { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(12)]
        public string RG { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
