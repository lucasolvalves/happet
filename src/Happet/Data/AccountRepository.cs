using Happet.Interfaces;
using Happet.Models;
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
    }
}
