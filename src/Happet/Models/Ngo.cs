using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happet.Models
{
    [Table("Ngos")]
    public class Ngo
    {
        [Key]
        [ForeignKey("People")]
        [Column(Order = 1)]
        public Guid IdPeople { get; set; }
        public virtual People People { get; set; }

        [Required]
        [StringLength(100)]
        public string FantasyName { get; set; }

        [Required]
        [StringLength(18)]
        public string CNPJ { get; set; }
    }
}