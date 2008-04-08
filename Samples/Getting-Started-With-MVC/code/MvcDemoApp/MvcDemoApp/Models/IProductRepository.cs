using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcDemoApp.Models
{
    public interface IProductRepository
    {
        List<Product> GetTenProducts();
        Product GetProductById(int id);
    }
}
