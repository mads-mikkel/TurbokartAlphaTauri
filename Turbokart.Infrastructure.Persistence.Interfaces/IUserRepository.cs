using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;

namespace Turbokart.Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository :IRepository<User>
    {
        Task<bool> IsUserInSystem(string username, string password);
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
