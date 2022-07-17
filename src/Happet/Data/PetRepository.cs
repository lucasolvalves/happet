using Happet.Interfaces;
using Happet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Data
{
    public class PetRepository : IPetRepository
    {
        private readonly HappetDbContext _context;

        public PetRepository(HappetDbContext context)
        {
            _context = context;
        }

        public async Task AddPetAsync(Pet pet)
        {
            try
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pet> GetPetsByIdPeople(Guid idPeople)
        {
            try
            {
                var pets = _context.Pets
                    .Include(x => x.People)
                    .Include(x => x.VaccineCard)
                    .ThenInclude(y => y.VacineCardItems)
                    .ThenInclude(z => z.Vaccine)
                    .Include(x => x.Adoptions)
                    .Where(x => x.IdPeople == idPeople)
                    .AsNoTracking()
                    .AsEnumerable();

                return pets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Pet> GetPetByIdAsync(Guid id)
        {
            try
            {
                var pet = _context.Pets
                    .Include(x => x.People)
                    .Include(o => o.Donations)
                    .Include(o => o.Adoptions)
                    .Include(x => x.VaccineCard)
                    .ThenInclude(y => y.VacineCardItems)
                    .ThenInclude(z => z.Vaccine)
                    .SingleOrDefaultAsync(x => x.Id == id);

                return pet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            try
            {
                _context.Pets.Update(pet);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePetAsync(Pet pet)
        {
            try
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pet> GetPets()
        {
            try
            {
                var pets = _context.Pets
                    .Include(x => x.People)
                    .AsNoTracking()
                    .AsEnumerable();

                return pets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ToAdoptAsync(Adopt adopt)
        {
            try
            {
                _context.Add(adopt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pet> GetAdoptedPetsByIdPeople(Guid idPeople)
        {
            try
            {
                var pets = _context.Pets
                    .Include(x => x.People)
                    .Include(x => x.VaccineCard)
                    .ThenInclude(y => y.VacineCardItems)
                    .ThenInclude(z => z.Vaccine)
                    .Where(x => x.Adoptions.Any(x => x.IdPeople == idPeople))
                    .AsNoTracking()
                    .AsEnumerable();

                return pets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
