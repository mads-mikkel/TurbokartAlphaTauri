using System;
using System.Collections.Generic;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels
{
    public class IndexModel
    {
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int DaysAhead { get; set; } = 7;
        public List<Booking> Bookings { get; set; }
    }
}
