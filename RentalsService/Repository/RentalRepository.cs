using Microsoft.EntityFrameworkCore;
using RentalsService.Database;
using RentalsService.Entities;
using RentalsService.IRepository;

namespace RentalsService.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalDbContext _context;

        public RentalRepository(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _context.AnuRentals.ToListAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            return await _context.AnuRentals.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _context.AnuRentals.AddAsync(rental);
        }

        public async Task<Rental> UpdateRentalAsync(Rental book)
        {
            _context.AnuRentals.Update(book);
            return book;
        }


        public async Task DeleteRentalAsync(int id)
        {
            var rental = await _context.AnuRentals.FindAsync(id);
            if (rental != null)
            {
                _context.AnuRentals.Remove(rental);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
