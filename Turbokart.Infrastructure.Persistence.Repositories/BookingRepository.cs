using Microsoft.EntityFrameworkCore;

using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Infrastructure.Persistence.Repositories
{
    public class BookingRepository: RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Booking>> GetAll()
        {
            return await set.Include(b => b.Customer).ToArrayAsync();
        }

        public async Task<IEnumerable<Booking>> GetTodaysBookings()
        {
            return await set.Include(b => b.Customer)
                .Where(b => b.Date.Date == DateTime.Today).ToArrayAsync();
        }

        public async Task<IEnumerable<Booking>> GetCustomersBookings(int id)
        {
            return await set.Include(b => b.Customer)
                .Where(b => b.CustomerId == id).ToArrayAsync();
        }

        public async override Task<Booking> GetBy(object id)
        {
         
            return await set.Include(b => b.Customer)
                .Where(b => b.BookingId == (int)id)
                .FirstOrDefaultAsync();
        }
        public async Task<Booking> GetLatestBooking()
        {
            return await set.Include(b => b.Customer)
                .OrderByDescending(b => b.BookingId).FirstOrDefaultAsync();
        }

        public async Task DeleteBooking(Booking booking)
        {
            set.Remove(booking);
        }

        public async Task<IEnumerable<Booking>> GetTodaysAndMoreBookings(ushort amount, DateOnly thisDate)
        {
            return await set.Include(b => b.Customer)
                .Where(b => b.Date.Date >= thisDate.ToDateTime(new TimeOnly()) && b.Date.Date <= thisDate.ToDateTime(new TimeOnly()).AddDays((int)amount)).ToArrayAsync();
        }
    }
}
