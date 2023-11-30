using Microsoft.AspNetCore.Mvc;
using Turbokart.Domain.Entities;

namespace Turbokart.Presentation.Apis.TurbokartAPI.Controllers
{
    [Route("/deleted")]
    [ApiController]
    public class DeletedBookingController : Controller
    {
        private readonly IDeletedBookingUseCase deletedBookingUseCase;

        public DeletedBookingController(IDeletedBookingUseCase deletedBookingUseCase)
        {
            this.deletedBookingUseCase = deletedBookingUseCase;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllDeletedBookings()
        {
            try
            {
                var deletedBookings = await deletedBookingUseCase.GetAllDeletedBookings();
                return Ok(deletedBookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetOneDeletedBooking(int id)
        {
            try
            {
                var deletedBooking = await deletedBookingUseCase.GetOneDeletedBooking(id);
                if (deletedBooking is null)
                {
                    return NotFound("Could not find a deleted booking with the id!");
                }
                return Ok(deletedBooking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> DeleteDeletedBooking(int id)
        {
            try
            {
                var deletedBooking = await deletedBookingUseCase.DeleteDeletedBooking(id);
                return Ok(deletedBooking);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}