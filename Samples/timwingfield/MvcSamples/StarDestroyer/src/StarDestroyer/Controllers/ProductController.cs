using System;
using System.Web.Mvc;
using StarDestroyer.Helpers.Filters;

namespace StarDestroyer.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController() : this(null)
        {
            
        }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? new ProductRepository();
        }

        [RequiresSuggestionsFilter]
        public ActionResult Search(string productName)
        {
            var product = _productRepository.GetProduct(productName);

            return View("Search", product);
        }
    }

    public interface IProductRepository
    {
        Product GetProduct(string productName);
    }

    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(string productName)
        {
            return new Product() { Description = productName + " description", Name = productName };
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}