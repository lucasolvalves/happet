using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Interfaces
{
    public interface IPetRepository
    {
        Task AddPetAsync(Pet pet);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(Pet pet);
        IEnumerable<Pet> GetPets();
        Task<Pet> GetPetByIdAsync(Guid id);
        IEnumerable<Pet> GetPetsByIdPeople(Guid idPeople);
        IEnumerable<Pet> GetAdoptedPetsByIdPeople(Guid idPeople);
        Task ToAdoptAsync(Adopt adopt);
    }
}