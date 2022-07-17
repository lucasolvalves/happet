using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Interfaces
{
    public interface IDonationRepository
    {
        Task AddDonationAsync(Donation donation);
        IEnumerable<Donation> GetDonationsByNgo(Guid idPeople);
    }
}
