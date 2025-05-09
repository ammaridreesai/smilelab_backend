using System.Linq.Expressions;


namespace SmileLabs_BE.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T?> GetSingleAsync(object id);

        // Add or update an entity (Upsert)
        Task UpsertAsync(T entity);

        // Add a range of entities
        Task AddRangeAsync(IEnumerable<T> entities);

        // Retrieve all entities that match a filter
        Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter);

        // Delete an entity by its primary key
        Task DeleteAsync(object id);

        // Save changes to the database
        Task<int> SaveChangesAsync();
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
