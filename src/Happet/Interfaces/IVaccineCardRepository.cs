using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Interfaces
{
    public interface IVaccineCardRepository
    {
        Task AddVaccineCardAsync(VaccineCard vaccineCard);
        Task DeleteVaccineCardAsync(VaccineCard vaccineCard);
    }
}