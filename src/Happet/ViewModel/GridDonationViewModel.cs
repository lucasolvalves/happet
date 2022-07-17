using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class GridDonationViewModel
    {
        public Guid Id { get; set; }
        public string PetName { get; set; }
        public float Value { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
