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
        public string AccupationArea { get; set; }

        [Required]
        public int CellPhone { get; set; }

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
        public int CEP { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}
        