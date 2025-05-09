using Microsoft.EntityFrameworkCore;
using SmileLabs_BE.Data;
using System.Linq.Expressions;

namespace SmileLabs_BE.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Retrieve a single entity by its primary key
        public async Task<T?> GetSingleAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Add or update an entity (Upsert)
        public async Task UpsertAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        // Add a range of entities
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        // Retrieve all entities that match a filter
        public async Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        // Delete an entity by its primary key
        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
        }

        // Save changes to the database
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        // Get all entities
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Get entities by filter
        public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }
    }
}
