using MongoDb.Data.Interfaces;

namespace WebApi.Options
{
    public class MongoDbOptions : IDatabaseOptions
    {
        public const string SectionKey = nameof(MongoDbOptions);
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}