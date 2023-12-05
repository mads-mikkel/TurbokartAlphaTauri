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

        [HttpGet("Create")]
        public async Task<ActionResult<CreateModel>> Create()
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            return View(new CreateModel());
        }

        [HttpPost("Create")]
        public async Task<ActionResult<EditModel>> Create([FromForm]CreateModel model)
        {           

            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                var newDate = DateTime.Now;
                string[] timeParts = model.Time.Split(':');

                if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minute))
                {
                    // Add hour and minute to the DateTime object
                    newDate = model.Date.ToDateTime(new TimeOnly().AddHours(hour).AddMinutes(minute));
                }
                else
                {
                    return View(model);
                }
                Booking newBooking = new Booking();
                newBooking.Grandprix = model.Grandprix;
                newBooking.Date = newDate;
                newBooking.Amount = model.Amount;

                Customer customer = new Customer();
                customer.Name = model.Email.Split('@')[0];
                customer.Email = model.Email;
                customer.Phonenumber = model.Phonenumber;

                await bookingUseCase.BookNew(newBooking, customer);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<ActionResult<EditModel>> Edit(int id)
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            Booking booking = await bookingUseCase.GetOneBooking(id);
            EditModel model = new()
            {
                Grandprix = booking.Grandprix,
                Date = DateOnly.FromDateTime(booking.Date),
                Time = booking.Date.ToString("hh:mm"),
                Amount = (byte)booking.Amount
            };
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<ActionResult<EditModel>> Edit(int id, [FromForm]EditModel model)
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                Booking booking = await bookingUseCase.GetOneBooking(id);
                booking.Grandprix = model.Grandprix;
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
        public async Task<ActionResult<DeleteModel>> Delete(int id)
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            var model = new DeleteModel();
            model.Booking = await bookingUseCase.GetOneBooking(id);
            return View(model);
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult<Booking>> Delete(int id, DeleteModel model)
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Index", "Login");
            if(model.Reason.Length > 0)
            {
                await bookingUseCase.DeleteBooking(id, model.Reason);
                return RedirectToAction("Index", "Home");
            }
            return View(await bookingUseCase.GetOneBooking(id));
        }
    }
}
