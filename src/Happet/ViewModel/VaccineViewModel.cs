using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public class VaccineViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }
}
