namespace MongoDb.Data.Interfaces
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}