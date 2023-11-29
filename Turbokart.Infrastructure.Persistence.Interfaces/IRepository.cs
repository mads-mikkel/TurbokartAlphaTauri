namespace Turbokart.Infrastructure.Persistence.Interfaces
{
    public interface IRepository<T>
    {
        Task Save(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetBy(object id);
        Task Update(T entity);
    }
}