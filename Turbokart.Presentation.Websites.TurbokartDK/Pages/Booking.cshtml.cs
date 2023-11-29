using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

namespace Turbokart.Presentation.Websites.TurbokartDK.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IBookingUseCase bookingUseCase;

        [BindProperty, Required]
        public string Grandprix { get; set; }
        [BindProperty, Required]
        public string Email { get; set; }
        [BindProperty, Required]
        public string Phonenumber { get; set; }
        [BindProperty, Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [BindProperty, Required]
        public string Time {  get; set; }
        [BindProperty, Required]
        public uint Amount { get; set; }

        public BookingModel(
            IBookingUseCase bookingUseCase
            )
        {
            this.bookingUseCase = bookingUseCase;
        }

        public IEnumerable<Booking> bookings { get; set; }

        public async Task<IActionResult> OnGet()
        {
            bookings = await bookingUseCase.GetAllBookings();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var grandprix = Grandprix;
            var email = Email;
            var phonenumber = Phonenumber;
            var date = Date;
            var time = Time;
            var amount = Amount;

            string[] timeParts = time.Split(':');

            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minute))
            {
                // Add hour and minute to the DateTime object
                date = date.AddHours(hour).AddMinutes(minute);
            }
            else
            {
                return Page();
            }

            Console.WriteLine(date.Hour);
            Console.WriteLine(date.Minute);

            if (ModelState.IsValid)
            {
                // TODO: Handle to check existing customer
                Booking newBooking = new Booking();
                newBooking.Grandprix = grandprix;
                newBooking.Email = email;
                newBooking.Phonenumber = phonenumber;
                newBooking.Date = date;
                newBooking.Amount = amount;

                Customer customer = new Customer();
                customer.Name = email.Split('@')[0];

                await bookingUseCase.BookNew(newBooking, customer);

                return Redirect("/Index");
            }

            return Page();
        }
    }
}
