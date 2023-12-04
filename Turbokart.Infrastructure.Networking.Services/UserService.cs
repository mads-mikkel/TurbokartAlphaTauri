using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using static Turbokart.Presentation.Apis.TurbokartAPI.Controllers.BookingController;

namespace Turbokart.Infrastructure.Networking.Services
{
    public class UserService : IUserUseCase
    {
        string uri = "http://localhost:5292/userCheck";
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (HttpClient client = new())
            {
                var result = await client.GetFromJsonAsync<IEnumerable<User>>(uri);

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
                var result = await client.GetFromJsonAsync<User>(uri + "/" + id.ToString());

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
                var result = await client.GetFromJsonAsync<User>(uri + "/oneuser?username=" + Uri.EscapeDataString(username) + "&password=" + Uri.EscapeDataString(password));

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
                var result = await client.GetFromJsonAsync<bool>(uri + "/user?username=" + Uri.EscapeDataString(username) + "&password=" + Uri.EscapeDataString(password));

                return result;
            }
        }

        public async Task<User> NewUser(User user)
        {
            using (HttpClient client = new())
            {
                var result = await client.PostAsJsonAsync(uri, user)
                    .Result.Content.ReadFromJsonAsync<User>();

                if (result is null)
                {
                    return new();
                }

                return result;
            }
        }
    }
}
