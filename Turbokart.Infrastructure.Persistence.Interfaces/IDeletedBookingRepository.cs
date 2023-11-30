using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;

namespace Turbokart.Infrastructure.Persistence.Interfaces
{
    public interface IDeletedBookingRepository : IRepository<DeletedBooking>
    {
        Task DeleteBooking(DeletedBooking deletedBooking);

    }
}
