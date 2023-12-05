using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;

namespace Turbokart.Infrastructure.Networking.Services
{
    public class DeletedBookingService : IDeletedBookingUseCase
    {
        string uri = "http://localhost:5292/api";
        public async Task<IEnumerable<DeletedBooking>> DeleteDeletedBooking(int id)
        {
            using (HttpClient client = new())
            {
                var result = await client.DeleteFromJsonAsync<IEnumerable<Booking>>(uri + "/" + id.ToString() + "?reason=" + Uri.EscapeDataString(reason));

                if (result is null)
                {
                    return new DeletedBooking[0];
                }

                return result;
            }
        }

        public async Task<IEnumerable<DeletedBooking>> GetAllDeletedBookings()
        {
            using (HttpClient client = new())
            {
                var result = await client.DeleteFromJsonAsync<IEnumerable<Booking>>(uri + "/" + id.ToString() + "?reason=" + Uri.EscapeDataString(reason));

                if (result is null)
                {
                    return new DeletedBooking[0];
                }

                return result;
            }
        }

        public async Task<DeletedBooking> GetOneDeletedBooking(int id)
        {
            using (HttpClient client = new())
            {
                var result = await client.DeleteFromJsonAsync<IEnumerable<Booking>>(uri + "/" + id.ToString() + "?reason=" + Uri.EscapeDataString(reason));

                if (result is null)
                {
                    return new();
                }

                return result;
            }
        }
    }
}
