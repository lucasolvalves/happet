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
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Ngo> Ngos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineCard> VaccineCards { get; set; }
        public DbSet<VacineCardItem> VacineCardItems { get; set; }
        public DbSet<Adopt> Adoptions { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}