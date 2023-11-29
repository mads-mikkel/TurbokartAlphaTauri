using System.Text.Json.Serialization;
namespace Turbokart.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; } = 0;
        public string Name { get; set; }
        [JsonIgnore]
        public List<Booking>? Bookings { get; set; }
    }
}