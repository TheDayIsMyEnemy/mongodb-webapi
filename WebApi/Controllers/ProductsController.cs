using MongoDb.Data.Interfaces;
using MongoDb.Data.Models;
using WebApi.Options;

namespace WebApi.Controllers
{
    public class ProductsController : BaseController<Product, MongoDbOptions>
    {
        public ProductsController(IMongoDbRepository<Product, MongoDbOptions> repository)
            : base(repository)
        { }
    }
}