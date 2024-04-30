namespace MongoDb.Data.Interfaces
{
    public interface IMongoDbRepository<T, O>
        where T : IMongoDbEntity
        where O : IMongoDbOptions
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetAsync(string id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(string id, T entity);
        public Task RemoveAsync(string id);
    }
}