﻿using Turbokart.Application.Interfaces;
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

        public async Task<IEnumerable<Booking>> DeleteBooking(int id)
        {
            IBookingRepository bookingRepository = unitOfWork.BookingRepository;
            await bookingRepository.DeleteBooking(await GetOneBooking(id));
            await unitOfWork.Commit();
            return await GetAllBookings();
        }
    }
}