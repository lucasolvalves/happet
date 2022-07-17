using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Interfaces
{
    public interface IVaccineRepository
    {
        IEnumerable<Vaccine> GetVaccines();
    }
}
