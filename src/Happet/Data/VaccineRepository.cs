using Happet.Interfaces;
using Happet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Data
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly HappetDbContext _context;

        public VaccineRepository(HappetDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vaccine> GetVaccines()
        {
            try
            {
                var vaccines = _context.Vaccines
                    .AsNoTracking()
                    .AsEnumerable();

                return vaccines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
