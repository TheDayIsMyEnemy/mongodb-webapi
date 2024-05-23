using MongoDb.Data.Interfaces;
using MongoDb.Data.Models;
using WebApi.Options;

namespace WebApi.Controllers
{
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IRepository<Product> repository)
            : base(repository)
        { }
    }
}