using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

namespace Turbokart.Tests.UoWRazorTestApp.Pages
{
    public class IndexModel: PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBookingUseCase bookingUseCase;

        public IndexModel(ILogger<IndexModel> logger, IBookingUseCase bookingUseCase)
        {
            _logger = logger;
            this.bookingUseCase = bookingUseCase;
        }

        public IBookingUseCase BookingUseCase => bookingUseCase;

        public void OnGet()
        {

        }
    }
}