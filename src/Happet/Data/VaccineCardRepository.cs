using Happet.Interfaces;
using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Data
{
    public class VaccineCardRepository : IVaccineCardRepository
    {
        private readonly HappetDbContext _context;

        public VaccineCardRepository(HappetDbContext context)
        {
            _context = context;
        }

        public async Task AddVaccineCardAsync(VaccineCard vaccineCard)
        {
            try
            {
                _context.Add(vaccineCard);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteVaccineCardAsync(VaccineCard vaccineCard)
        {
            try
            {
                if (vaccineCard is null)
                    return;

                _context.VaccineCards.Remove(vaccineCard);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
