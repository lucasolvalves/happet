using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    [Table("Adoptions")]
    public class Adopt
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pet")]
        [Column(Order = 1)]
        public Guid? IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        [ForeignKey("People")]
        [Column(Order = 1)]
        public Guid IdPeople { get; set; }
        public virtual People People { get; set; }

        public EStatusAdopt Status { get; set; }

        public bool AdoptionTerm { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}
