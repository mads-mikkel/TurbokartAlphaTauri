using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels
{
    public class IndexModel
    {
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Range(0, ushort.MaxValue)]
        public ushort DaysAhead { get; set; } = 7;
        public IEnumerable<Booking> Bookings { get; set; } = new Booking[0];
    }
}
