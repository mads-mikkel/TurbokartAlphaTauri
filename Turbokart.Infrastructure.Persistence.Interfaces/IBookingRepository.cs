using Turbokart.Domain.Entities;

namespace Turbokart.Infrastructure.Persistence.Interfaces
{
    public interface IBookingRepository: IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetTodaysBookings();

        Task<IEnumerable<Booking>> GetCustomersBookings(int id);
        Task<Booking> GetLatestBooking();

        Task DeleteBooking(Booking booking);
    }
}