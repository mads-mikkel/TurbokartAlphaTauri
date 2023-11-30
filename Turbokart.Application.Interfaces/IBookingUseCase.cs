using Turbokart.Domain.Entities;

namespace Turbokart.Application.Interfaces
{
    public interface IBookingUseCase
    {
        Task<Booking> BookNew(Booking booking, Customer customer);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<IEnumerable<Booking>> GetTodaysBookings();
        Task<Booking> GetOneBooking(int id);
        Task<IEnumerable<Booking>> GetCustomersBookings(int id);
        Task<Booking> UpdateBooking(Booking booking);

        Task<IEnumerable<Booking>> DeleteBooking(int id, string reason);
        Task<IEnumerable<Booking>> GetTodaysAndMoreBookings(ushort amount, DateOnly thisDate);
    }
}