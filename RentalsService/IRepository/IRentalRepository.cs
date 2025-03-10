using RentalsService.Entities;

namespace RentalsService.IRepository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
        Task<Rental> UpdateRentalAsync(Rental book);
        Task SaveChangesAsync();
    }
}
