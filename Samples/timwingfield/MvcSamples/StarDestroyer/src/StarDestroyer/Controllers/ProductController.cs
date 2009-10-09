using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.Attributes;
using StarDestroyer.Helpers.Filters;
using StarDestroyer.Models;

namespace StarDestroyer.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController()
            : this(null)
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

        [AcceptGet()]
        public ActionResult Catalog()
        {
            var products = _productRepository.GetProductCatalog();
            return View(products);
        }
    }

    public interface IProductRepository
    {
        ProductModel GetProduct(string productName);
        List<ProductListingModel> GetProductCatalog();
    }

    public class ProductRepository : IProductRepository
    {
        public ProductModel GetProduct(string productName)
        {
            return new ProductModel() { Description = productName + " description", Name = productName };
        }

        public List<ProductListingModel> GetProductCatalog()
        {
            return new List<ProductListingModel>()
                       {
                           new ProductListingModel() {InStock = true, Name = "Rebellion Era Campaign Guide", Price = 23.99m},
                           new ProductListingModel() {InStock = true, Name = "The Clone Wars Map Pack 2", Price = 33.11m},
                           new ProductListingModel() {InStock = false, Name = "Jedi Academy Booster Pack", Price = 2.99m}
                       };
        }
    }
}