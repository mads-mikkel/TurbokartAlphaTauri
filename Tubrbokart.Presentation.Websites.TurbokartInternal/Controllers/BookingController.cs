using Microsoft.AspNetCore.Mvc;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Controllers
{
    [Route("[controller]/")]
    public class BookingController : Controller
    {
        private readonly IBookingUseCase bookingUseCase;

        public BookingController(IBookingUseCase bookingUseCase)
        {
            this.bookingUseCase = bookingUseCase;
        }

        [HttpGet("Edit/{id}")]
        public async Task<ActionResult<EditModel>> Edit(int id)
        {
            Booking booking = await bookingUseCase.GetOneBooking(id);
            EditModel model = new()
            {
                Grandprix = booking.Grandprix,
                Email = booking.Email,
                Phonenumber = booking.Phonenumber,
                Date = DateOnly.FromDateTime(booking.Date),
                Time = booking.Date.ToString("hh:mm"),
                Amount = (byte)booking.Amount
            };
            return View(model);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
