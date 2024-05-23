using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDb.Data.Interfaces;

namespace MongoDb.Data.Repositories
{
    public class MongoDbRepository<T> : IRepository<T>
        where T : IEntity
    {
        protected readonly IMongoCollection<T> Collection;
        protected readonly IDatabaseOptions MongoDbOptions;

        public MongoDbRepository(IDatabaseOptions mongoDbOptions)
        {
            MongoDbOptions = mongoDbOptions;

            var mongoClient = new MongoClient(MongoDbOptions.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(MongoDbOptions.DatabaseName);

            Collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAllAsync()
            => await Collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id)
            => await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T newEntity)
           => await Collection.InsertOneAsync(newEntity);

        public async Task UpdateAsync(string id, T updatedEntity)
            => await Collection.ReplaceOneAsync(x => x.Id == id, updatedEntity);

        public async Task DeleteAsync(string id)
            => await Collection.DeleteOneAsync(x => x.Id == id);

        public async Task UpsertAsync(Expression<Func<T, bool>> fiter, T entity)
            => await Collection.ReplaceOneAsync(fiter, entity, new ReplaceOptions { IsUpsert = true });
    }
}