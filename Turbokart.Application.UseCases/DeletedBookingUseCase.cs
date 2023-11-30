using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Application.UseCases
{
    public class DeletedBookingUseCase : IDeletedBookingUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDeletedBookingRepository deletedBookingRepository;

        public DeletedBookingUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            deletedBookingRepository = unitOfWork.DeletedBookingRepository;
        }

        public async Task<IEnumerable<DeletedBooking>> DeleteDeletedBooking(int id)
        {
            await deletedBookingRepository.DeleteBooking(await GetOneDeletedBooking(id));
            await unitOfWork.Commit();
            return await deletedBookingRepository.GetAll();
        }

        public async Task<IEnumerable<DeletedBooking>> GetAllDeletedBookings()
        {
            return await deletedBookingRepository.GetAll();
        }

        public async Task<DeletedBooking> GetOneDeletedBooking(int id)
        {
            return await deletedBookingRepository.GetBy(id);
        }
    }
}
