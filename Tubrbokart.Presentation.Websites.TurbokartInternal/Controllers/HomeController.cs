using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models;
using Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

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
            if (Request.Cookies["Username"] is null) return RedirectToAction("Login", "Account");
            var viewModel = new IndexModel();
            viewModel.Bookings = await bookingUseCase.GetTodaysAndMoreBookings(viewModel.DaysAhead, viewModel.Date);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexModel model)
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Login", "Account");
            var viewModel = model;
            if (ModelState.IsValid)
            {
                viewModel.Bookings = await bookingUseCase.GetTodaysAndMoreBookings(viewModel.DaysAhead, viewModel.Date);
                return View(viewModel);
            }
            viewModel.Bookings = new Booking[0];
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            if (Request.Cookies["Username"] is null) return RedirectToAction("Login", "Account");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}