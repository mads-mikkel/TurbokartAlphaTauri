namespace Turbokart.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task Commit();
        void RollBack();
        IBookingRepository BookingRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IDeletedBookingRepository DeletedBookingRepository { get; }
    }
}