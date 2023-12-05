using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbokart.Domain.Entities
{
    public class DeletedBooking
    {
        public int DeletedBookingId { get; set; }
        public int BookingId { get; set; }
        public string Grandprix { get; set; }
        public DateTime Date { get; set; }
        public uint Amount { get; set; }
        public Customer? Customer { get; set; } = null;
        public int CustomerId { get; set; } = 0;
        public string ReasonOfDeletion { get; set; }
    }
}
