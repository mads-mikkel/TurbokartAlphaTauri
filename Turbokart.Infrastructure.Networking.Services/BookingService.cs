using System.Net;
using System.Net.Http.Json;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using static Turbokart.Presentation.Apis.TurbokartAPI.Controllers.BookingController;

namespace Turbokart.Infrastructure.Networking.Services
{
    public class BookingService : IBookingUseCase
    {
        string uri = "http://localhost:5292/api";
        public async Task<Booking> BookNew(Booking booking, Customer customer)
        {
            using(HttpClient client = new())
            {
                var result = await client.PostAsJsonAsync(uri, new BookingCreationModel() { Booking = booking, Customer = customer })
                    .Result.Content.ReadFromJsonAsync<Booking>();
                
                if(result is null)
                {
                    return new();
                }

                return result;
            }
        }

        public async Task<IEnumerable<Booking>> DeleteBooking(int id, string reason)
        {
            using (HttpClient client = new())
            {
                var result = await client.DeleteFromJsonAsync<IEnumerable<Booking>>(uri + "/" + id.ToString());

                if (result is null)
                {
                    return new Booking[0];
                }

                return result;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            using (HttpClient client = new())
            {
                var result = await client.GetFromJsonAsync<IEnumerable<Booking>>(uri);

                if (result is null)
                {
                    return new Booking[0];
                }

                return result;
            }
        }

        public async Task<IEnumerable<Booking>> GetCustomersBookings(int id)
        {
            using (HttpClient client = new())
            {
                var result = await client.GetFromJsonAsync<IEnumerable<Booking>>(uri + "/customer/" + id.ToString());

                if (result is null)
                {
                    return new Booking[0];
                }

                return result;
            }
        }

        public async Task<Booking> GetOneBooking(int id)
        {
            using (HttpClient client = new())
            {
                var result = await client.GetFromJsonAsync<Booking>(uri + "/" + id.ToString());

                if (result is null)
                {
                    return new();
                }

                return result;
            }
        }

        public async Task<IEnumerable<Booking>> GetTodaysBookings()
        {
            using (HttpClient client = new())
            {
                var result = await client.GetFromJsonAsync<IEnumerable<Booking>>(uri + "/today");

                if (result is null)
                {
                    return new Booking[0];
                }

                return result;
            }
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            using (HttpClient client = new())
            {
                var result = await client.PutAsJsonAsync(uri, booking)
                    .Result.Content.ReadFromJsonAsync<Booking>();

                if (result is null)
                {
                    return new();
                }

                return result;
            }
        }
        public async Task<IEnumerable<Booking>> GetTodaysAndMoreBookings(ushort amount, DateOnly thisDate)
        {
            using (HttpClient client = new())
            {
                string url = uri + "/thisDateAndMore?amount=" + amount.ToString() + "&thisDate=" + thisDate.ToString("MM/dd/yyyy");
                var result = await client.GetFromJsonAsync<IEnumerable<Booking>>(url);
                if (result is null)
                {
                    return new Booking[0];
                }
                return result;
            }
        }
    }
}