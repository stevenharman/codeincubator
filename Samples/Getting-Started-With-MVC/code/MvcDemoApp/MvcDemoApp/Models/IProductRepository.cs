using System.Collections.Generic;

namespace MvcDemoApp.Models
{
    public interface IProductRepository
    {
        List<Product> GetTenProducts();
        Product GetProductById(int id);
    }
}
