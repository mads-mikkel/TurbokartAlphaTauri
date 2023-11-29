using System;
using System.Collections.Generic;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels
{
    public class IndexModel
    {
        public DateTime Date { get; set; }
        public int DaysAhead {  get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
