namespace Buntu.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> AllReadonly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        Task DeleteAsync<T>(object id) where T: class;
        Task<int> SaveChangesAsync();
    }
}
