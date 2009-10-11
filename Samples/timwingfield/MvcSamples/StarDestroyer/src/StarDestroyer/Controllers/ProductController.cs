using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.Attributes;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;
using StarDestroyer.Helpers.Filters;
using StarDestroyer.Models;
using System.Linq;

namespace StarDestroyer.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _productRepository;

        public ProductController()
            : this(null)
        {

        }

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? new Repository<Product>();
        }

        [RequiresSuggestionsFilter]
        public ActionResult Search(string productName)
        {
            var product = _productRepository.Where(x => x.ShortName == productName).FirstOrDefault();

            return View("Search", product.ToProductModel());
        }

        [AcceptGet()]
        public ActionResult Catalog()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }
}