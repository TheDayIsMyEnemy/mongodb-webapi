using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDb.Data.Interfaces;

namespace MongoDb.Data.Models
{
    public abstract class MongoDbEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
    }
}