using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalsService.Entities;
using RentalsService.IService;

namespace RentalsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null) return NotFound();
            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> AddRental([FromBody] Rental rental)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _rentalService.AddRentalAsync(rental);
            return CreatedAtAction(nameof(GetRentalById), new { id = rental.Id }, rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] Rental book)
        {
            try
            {
                var rentalresponse = await _rentalService.UpdateRentalAsync(book);
                return Ok(rentalresponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null) return NotFound();

            await _rentalService.DeleteRentalAsync(id);
            return NoContent();
        }
    }
}
