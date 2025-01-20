using Microsoft.EntityFrameworkCore;
using Drugsearch.Models;

namespace PharmacyAPI.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }

        public DbSet<Drug> Drugs { get; set; }
    }
}