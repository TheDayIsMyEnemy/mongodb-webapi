using System.Text.Json.Serialization;
using MongoDb.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Data.Models
{
    public class Product : IMongoDbEntity
    {
        [BsonIgnore]
        [JsonIgnore]
        private decimal? _price;

        [BsonIgnore]
        [JsonIgnore]
        private int? _quantity;

        [BsonIgnore]
        [JsonIgnore]
        private bool _availability;

        public Product() { }

        public Product(
            string id,
            string brand,
            decimal price)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Price = price;
        }

        public Product(
            string id,
            string brand,
            decimal price,
            int? quantity,
            bool availability)
            : this(id, brand, price)
        {
            Quantity = quantity;
            Availability = availability;
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public decimal? Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value.HasValue)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Price cannot be less than zero", nameof(value));
                    }
                    else
                    {
                        _price = value;
                        LastUpdated = DateTime.UtcNow;
                    }
                }
            }
        }

        public int? Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value.HasValue)
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Quantity cannot be less than zero", nameof(value));
                    }
                    else
                    {
                        _quantity = value;
                        LastUpdated = DateTime.UtcNow;
                    }
                }
            }
        }

        public bool Availability
        {
            get
            {
                return _availability;
            }
            set
            {
                if (_availability != value)
                {
                    _availability = value;
                    LastUpdated = DateTime.UtcNow;
                }
            }
        }

        public DateTime LastUpdated { get; private set; }
    }
}