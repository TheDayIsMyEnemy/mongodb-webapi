namespace MongoDb.Data.Interfaces
{
    public interface IMongoDbOptions
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}