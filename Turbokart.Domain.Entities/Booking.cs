
namespace Turbokart.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Grandprix { get; set; }
        public DateTime Date { get; set; }
        public uint Amount { get; set; }
        public Customer? Customer { get; set; } = null;
        public int CustomerId { get; set; } = 0;
    }
}