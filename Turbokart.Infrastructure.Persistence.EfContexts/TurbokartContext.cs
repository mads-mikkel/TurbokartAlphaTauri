using Microsoft.EntityFrameworkCore;

using Turbokart.Domain.Entities;

namespace Turbokart.Infrastructure.Persistence.EfContexts
{
    public class TurbokartContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TurbokartDb23;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId)
                .HasPrincipalKey(c => c.CustomerId);
        }
    }
}