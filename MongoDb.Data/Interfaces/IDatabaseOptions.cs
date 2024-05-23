namespace MongoDb.Data.Interfaces
{
    public interface IDatabaseOptions
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}