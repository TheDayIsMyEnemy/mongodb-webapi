using MongoDB.Driver;
using MongoDb.Data.Interfaces;

namespace MongoDb.Data.Repositories
{
    public class MongoDbRepository<T, O> : IMongoDbRepository<T, O>
        where T : IMongoDbEntity
        where O : IMongoDbOptions, new()
    {
        protected readonly IMongoCollection<T> Collection;
        protected readonly O MongoDbOptions;

        public MongoDbRepository(O mongoDbOptions)
        {
            MongoDbOptions = mongoDbOptions;

            var mongoClient = new MongoClient(MongoDbOptions.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(MongoDbOptions.DatabaseName);

            Collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAllAsync() =>
            await Collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id) =>
            await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T newEntity) =>
            await Collection.InsertOneAsync(newEntity);

        public async Task UpdateAsync(string id, T updatedEntity) =>
            await Collection.ReplaceOneAsync(x => x.Id == id, updatedEntity);

        public async Task RemoveAsync(string id) =>
            await Collection.DeleteOneAsync(x => x.Id == id);
    }
}