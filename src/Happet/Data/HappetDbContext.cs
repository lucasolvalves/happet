using Happet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Happet.Data
{
    public class HappetDbContext : IdentityDbContext
    {
        public HappetDbContext(DbContextOptions<HappetDbContext> options)
            : base(options)
        {
        }

        public DbSet<People> People { get; set; }
        public DbSet<Adopter> Adopter { get; set; }
        public DbSet<Ngo> Ngo { get; set; }
    }
}