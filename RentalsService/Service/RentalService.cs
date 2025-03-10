using Microsoft.EntityFrameworkCore;
using RentalsService.Entities;
using RentalsService.IRepository;
using RentalsService.IService;

namespace RentalsService.Service
{
    public class RentalService: IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _rentalRepository.GetAllRentalsAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            return await _rentalRepository.GetRentalByIdAsync(id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _rentalRepository.AddRentalAsync(rental);
            await _rentalRepository.SaveChangesAsync();
        }

        public async Task<Rental> UpdateRentalAsync(Rental book)
        {
            var existingbook = await _rentalRepository.GetRentalByIdAsync(book.Id);
            if (existingbook == null)
            {
                throw new Exception("Rental is not found");
            }
            var response = await _rentalRepository.UpdateRentalAsync(book);
            await _rentalRepository.SaveChangesAsync();
            return response;
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
            await _rentalRepository.SaveChangesAsync();
        }
    }
}
