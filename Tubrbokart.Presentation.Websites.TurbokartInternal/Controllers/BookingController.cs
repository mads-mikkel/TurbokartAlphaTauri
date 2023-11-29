using Microsoft.AspNetCore.Mvc;
using Turbokart.Application.Interfaces;

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
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
