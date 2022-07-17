using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("People")]
        [Column(Order = 1)]
        public Guid IdPeople { get; set; }
        public virtual People People { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Breed { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        [Required]
        public ETypeGender TypeGender { get; set; }

        [Required]
        public bool Castrated { get; set; }

        [ForeignKey("VaccineCard")]
        [Column(Order = 1)]
        public Guid? IdVaccineCard { get; set; }
        public virtual VaccineCard VaccineCard { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        public ETypePet TypePet { get; set; }

        [Required]
        public byte[] ImageBytes { get; set; }

        [Required]
        public string ImageDescription { get; set; }

        [StringLength(200)]
        public string Observation { get; set; }

        [Required]
        public EStatusPet Status { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }

        public virtual IEnumerable<Donation> Donations { get; set; }
        public virtual IEnumerable<Adopt> Adoptions { get; set; }
    }
}
