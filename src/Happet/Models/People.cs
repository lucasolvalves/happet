using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happet.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("IdentityUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        [StringLength(50)]
        public string OccupationArea { get; set; }

        [Required]
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}
        