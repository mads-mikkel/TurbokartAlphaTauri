using Microsoft.AspNetCore.Mvc;
using Turbokart.Domain.Entities;

namespace Turbokart.Presentation.Apis.TurbokartAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingUseCase usecase;

        public BookingController(
            IBookingUseCase usecase
            )
        {
            this.usecase = usecase;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBoookings()
        {            
            try
            {
                var bookings = await usecase.GetAllBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/api/customer/{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetCustomersBoookings(int id)
        {
            try
            {
                var bookings = await usecase.GetCustomersBookings(id);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/api/today")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetTodaysBoookings()
        {           
            try
            {
                var bookings = await usecase.GetTodaysBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetOneBooking(int id)
        {           
            try
            {
                var booking = await usecase.GetOneBooking(id);
                if (booking is null)
                {
                    return NotFound("Could not find a booking with the id!");
                }
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public class BookingCreationModel
        {
            public Booking Booking { get; set; }
            public Customer Customer { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] BookingCreationModel model)
        {
            try
            {
                var newBooking = await usecase.BookNew(model.Booking, model.Customer);
                return Created("Created new booking", newBooking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Booking>> UpdateBooking([FromBody] Booking booking)
        {           
            
            try
            {
                var newBooking = await usecase.UpdateBooking(booking);
                return Ok(newBooking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> DeleteBooking(int id, string reason)
        {
            var newBookings = await usecase.DeleteBooking(id, reason);
            return Ok(newBookings);
        }
        [HttpGet("/api/thisDateAndMore")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetTodaysAndMoreBookings(ushort amount, DateOnly thisDate)
        {
            try
            {
                var bookings = await usecase.GetTodaysAndMoreBookings(amount, thisDate);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
