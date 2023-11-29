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
    public class DeletedBookingRepository : RepositoryBase<DeletedBooking>, IDeletedBookingRepository
    {
        public DeletedBookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteBooking(DeletedBooking deletedBooking)
        {
            set.Remove(deletedBooking);
        }
    }
}
