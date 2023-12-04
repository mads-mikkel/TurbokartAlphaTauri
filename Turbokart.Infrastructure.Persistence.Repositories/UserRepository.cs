using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await set.Where(b => b.Brugernavn == username && b.Password == password).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUserInSystem(string username, string password)
        {
            var isNull = await set.Where(b => b.Brugernavn == username && b.Password == password).FirstOrDefaultAsync();
            return isNull != null;
        }

    }
}
