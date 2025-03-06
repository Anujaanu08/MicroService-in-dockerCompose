using RentalsService.Entities;

namespace RentalsService.IService
{
    public interface IRentalService
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }
}
