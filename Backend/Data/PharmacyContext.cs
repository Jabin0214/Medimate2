using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Drugsearch.Models;

namespace PharmacyAPI.Data
{
    public class PharmacyContext : IdentityDbContext<ApplicationUser>
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) 
            : base(options) { }

        public DbSet<Drug> Drugs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Add any custom model configurations here if needed
        }
    }
}