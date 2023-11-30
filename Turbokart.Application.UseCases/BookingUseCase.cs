using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Application.UseCases
{
    public class BookingUseCase: IBookingUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public BookingUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Booking> BookNew(Booking booking, Customer customer)
        {
            booking.Customer = customer;

            if(customer.CustomerId == 0)    // handle new customer that does not exist in the DB.
            {
                ICustomerRepository customerRepository = unitOfWork.CustomerRepository;
                await customerRepository.Save(customer);
            }

            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            await bookingRepository.Save(booking);

            await unitOfWork.Commit();
            return await bookingRepository.GetLatestBooking();
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetAll();
        }

        public async Task<IEnumerable<Booking>> GetTodaysBookings()
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetTodaysBookings();
        }

        public async Task<Booking?> GetOneBooking(int id)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetBy(id);
        }
        public async Task<Booking> GetLatestBooking()
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetLatestBooking();
        }

        public async Task<IEnumerable<Booking>> GetCustomersBookings(int id)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetCustomersBookings(id);
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            await bookingRepository.Update(booking);
            await unitOfWork.Commit();
            return await GetOneBooking(booking.BookingId);
        }

        public async Task<IEnumerable<Booking>> DeleteBooking(int id, string reason)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            IDeletedBookingRepository deletedBookingRepository = unitOfWork.DeletedBookingRepository;

            var booking = await GetOneBooking(id);
            if(booking is not null)
            {
                DeletedBooking deletedBooking = new() { Amount = booking.Amount, BookingId = booking.BookingId, Customer = booking.Customer, CustomerId = booking.CustomerId, Date = booking.Date, Email = booking.Email, Grandprix = booking.Grandprix, Phonenumber = booking.Phonenumber, ReasonOfDeletion = reason };
                deletedBookingRepository.Save(deletedBooking);

                await bookingRepository.DeleteBooking(await GetOneBooking(id));
                await unitOfWork.Commit();
                return await GetAllBookings();
            }
            else
            {
                return await GetAllBookings();
            }
            
        }

        public async Task<IEnumerable<Booking>> GetTodaysAndMoreBookings(ushort amount, DateOnly thisDate)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            return await bookingRepository.GetTodaysAndMoreBookings(amount, thisDate);
        }
    }
}