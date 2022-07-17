using Happet.Interfaces;
using Happet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Data
{
    public class DonationRepository : IDonationRepository
    {
        private readonly HappetDbContext _context;

        public DonationRepository(HappetDbContext context)
        {
            _context = context;
        }

        public async Task AddDonationAsync(Donation donation)
        {
            try
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Donation> GetDonationsByNgo(Guid idPeople)
        {
            try
            {
                var pets = _context.Donations
                    .Include(x => x.Pet)
                    .Where(x => x.Pet.IdPeople == idPeople)
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
