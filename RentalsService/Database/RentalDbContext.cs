using Microsoft.EntityFrameworkCore;
using RentalsService.Entities;

namespace RentalsService.Database
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rental> AnuRentals { get; set; }
    }
}
