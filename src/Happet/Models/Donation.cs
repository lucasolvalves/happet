using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    [Table("Donations")]
    public class Donation
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pet")]
        [Column(Order = 1)]
        public Guid IdPet { get; set; }
        public virtual Pet Pet { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(16)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string District { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(9)]
        public string CEP { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public float Value { get; set; }

        [Required]
        public EStatusDonation Status { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PaymentDate { get; set; }
    }
}
