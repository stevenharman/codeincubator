using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MvcDemoApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        public List<Product> GetTenProducts()
        {
            return db.Products.Where(p => p.ListPrice > 0.0M).Take(10).ToList<Product>();
        }

        public Product GetProductById(int id)
        {
            return db.Products.Single<Product>(p => p.ProductID == id);
        }
    }
}
