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
    public class UserService : IUserUseCase
    {
        string uri = "http://localhost:5292/api";
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (HttpClient client = new())
            {
                var result = await client.DeleteFromJsonAsync<IEnumerable<Booking>>(uri + "/" + id.ToString() + "?reason=" + Uri.EscapeDataString(reason));

                if (result is null)
                {
                    return new User[0];
                }

                return result;
            }
        }

        public async Task<User> GetBy(int id)
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

        public async Task<User> GetOneUsers(string username, string password)
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

        public async Task<bool> IsUserInSystem(string username, string password)
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

        public async Task<User> NewUser(User user)
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
