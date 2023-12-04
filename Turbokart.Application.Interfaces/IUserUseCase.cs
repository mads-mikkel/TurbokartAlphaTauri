using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;

namespace Turbokart.Application.Interfaces
{
    public interface IUserUseCase
    {
        Task<User> NewUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> IsUserInSystem(string username, string password);
        Task<User> GetOneUsers(string username, string password);
        Task<User> GetBy(int id);
    }
}
