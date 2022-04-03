using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAdopterAsync(Adopter adopter);
        Task AddNgoAsync(Ngo ngo);
        Task UpdateAdopterAsync(Adopter adopter);
        Task UpdateNgoAsync(Ngo ngo);
        Task<People> GetPeopleByUserIdAsync(string userId);
        Task<Adopter> GetAdopterByPeopleIdAsync(Guid peopleId);
        Task<Ngo> GetNgoByPeopleIdAsync(Guid peopleId);
    }
}
