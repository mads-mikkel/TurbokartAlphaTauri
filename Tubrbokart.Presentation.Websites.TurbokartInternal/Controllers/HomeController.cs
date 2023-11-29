using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookingUseCase bookingUseCase;

        public HomeController(IBookingUseCase bookingUseCase)
        {
            this.bookingUseCase = bookingUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexModel();
            viewModel.Bookings = await bookingUseCase.GetAllBookings();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexModel model)
        {
            var viewModel = model;
            if (ModelState.IsValid)
            {

            }
            viewModel.Bookings = await bookingUseCase.GetAllBookings();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}