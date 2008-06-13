using System.Collections.Generic;
using System.Linq;

namespace MvcDemoApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private NorthwindDataContext db = new NorthwindDataContext();

        public List<Product> GetTenProducts()
        {
            return db.Products.Take(10).ToList();
        }

        public Product GetProductById(int id)
        {
            return db.Products.Single(p => p.ProductID == id);
        }

        public List<Category> GetAllProductCategories()
        {
            return db.Categories.ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return db.Products.Where(p => p.CategoryID == categoryId).ToList();
        }

    }
}
