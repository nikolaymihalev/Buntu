namespace Buntu.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> AllReadOnly<T>();
        Task AddAsync<T>(T entity) where T : class;
        Task<T> GetByIdAsync<T>(object id) where T : class;
        Task DeleteAsync<T>(object id) where T: class;
        Task<int> SaveChangesAsync();
    }
}
