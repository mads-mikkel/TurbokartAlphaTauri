using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private DbContext dbContext;
        private IBookingRepository bookingRepository;
        private ICustomerRepository customerRepository;
        private readonly IDeletedBookingRepository deletedBookingRepository;

        public UnitOfWork(
            DbContext dbContext, 
            IBookingRepository bookingRepository,
            ICustomerRepository customerRepository,
            IDeletedBookingRepository deletedBookingRepository)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            this.deletedBookingRepository = deletedBookingRepository ?? throw new ArgumentNullException(nameof(deletedBookingRepository));
        }

        public IBookingRepository BookingRepository => bookingRepository;

        public ICustomerRepository CustomerRepository => customerRepository;

        public IDeletedBookingRepository DeletedBookingRepository => deletedBookingRepository;
 
        public async Task Commit()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new UnitOfWorkException("Unable to commit transaction.", e);
            }
        }

        public void Dispose()
        {
            try
            {
                dbContext.Dispose();
            }
            catch(Exception e)
            {
                throw new UnitOfWorkException("Unable to dispose", e);
            }
            finally
            {
                dbContext = null;
            }
        }

        public void RollBack()
        {
            
        }
    }
}
