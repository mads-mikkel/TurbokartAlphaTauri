using Microsoft.AspNetCore.Mvc;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpPost("Edit/{id}")]
        public async Task<ActionResult<EditModel>> Edit(int id, [FromForm]EditModel model)
        {
            if (ModelState.IsValid)
            {
                Booking booking = await bookingUseCase.GetOneBooking(id);
                booking.Grandprix = model.Grandprix;
                booking.Email = model.Email;
                booking.Phonenumber = model.Phonenumber;
                string[] timeParts = model.Time.Split(':');
                if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minute))
                {
                    booking.Date = model.Date.ToDateTime(new TimeOnly().AddHours(hour).AddMinutes(minute));
                }
                booking.Amount = model.Amount;
                await bookingUseCase.UpdateBooking(booking);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
