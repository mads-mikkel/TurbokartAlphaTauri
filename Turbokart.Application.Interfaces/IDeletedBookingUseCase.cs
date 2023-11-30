using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;

namespace Turbokart.Application.Interfaces
{
    public interface IDeletedBookingUseCase
    {
        Task<IEnumerable<DeletedBooking>> GetAllDeletedBookings();
        Task<DeletedBooking> GetOneDeletedBooking(int id);
        Task<IEnumerable<DeletedBooking>> DeleteDeletedBooking(int id);
    }
}
