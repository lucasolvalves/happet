using Happet.Interfaces;
using Happet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HappetDbContext _context;

        public AccountRepository(HappetDbContext context)
        {
            _context = context;
        }

        public async Task AddAdopterAsync(Adopter adopter)
        {
            try
            {
                _context.Add(adopter);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddNgoAsync(Ngo ngo)
        {
            try
            {
                _context.Add(ngo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<People> GetPeopleByUserIdAsync(string userId)
        {
            try
            {
                var people = await _context.People
                    .Include(x => x.IdentityUser)
                    .SingleAsync(x => x.UserId == userId);

                return people;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Adopter> GetAdopterByPeopleIdAsync(Guid peopleId)
        {
            try
            {
                var adopter = await _context.Adopter
                    .Include(x => x.People)
                    .Include(x => x.People.IdentityUser)
                    .SingleAsync(x => x.IdPeople == peopleId);

                return adopter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ngo> GetNgoByPeopleIdAsync(Guid peopleId)
        {
            try
            {
                var ngo = await _context.Ngo
                    .Include(x => x.People)
                    .Include(x => x.People.IdentityUser)
                    .SingleAsync(x => x.IdPeople == peopleId);

                return ngo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAdopterAsync(Adopter adopter)
        {
            try
            {
                _context.Update(adopter);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateNgoAsync(Ngo ngo)
        {
            try
            {
                _context.Update(ngo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
