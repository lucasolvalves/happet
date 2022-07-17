using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class RegisterVaccineCardViewModel
    {
        public Guid Id { get; set; } 
        public Guid IdVaccine { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
