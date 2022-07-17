using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Models
{
    [Table("VacineCardItems")]
    public class VacineCardItem
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("VaccineCard")]
        [Column(Order = 1)]
        public Guid IdVaccineCard { get; set; }
        public virtual VaccineCard VaccineCard { get; set; }

        [ForeignKey("Vaccine")]
        [Column(Order = 1)]
        public Guid IdVaccine { get; set; }
        public virtual Vaccine Vaccine { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }
    }
}
