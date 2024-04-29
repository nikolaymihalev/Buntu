using Buntu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Infrastructure.Common
{
    public class Repository : IRepository
    {
        public DbContext Context { get; set; }

        private DbSet<T> DbSet<T>() where T : class 
        {
            return Context.Set<T>();
        }

        public Repository(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if(entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
