using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.Attributes;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;
using StarDestroyer.Helpers.Filters;
using StarDestroyer.Models;
using System.Linq;
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
            var product = _productRepository.Where(x => x.ShortName == productName).FirstOrDefault();

            return View("Search", product.ToProductModel());
        }

        [AcceptGet()]
        public ActionResult List(JQGridRequestModel gridRequest) 
        {
            

            var jsonData = new
            {
                total = 1, // we'll implement later 
                page = gridRequest.page,
                records = 3, // implement later 
                rows = new[]{
                      new {id = 1, cell = new[] {"1", "-7", "Is this a good question?"}},
                      new {id = 2, cell = new[] {"2", "15", "Is this a blatant ripoff?"}},
                      new {id = 3, cell = new[] {"3", "23", "Why is the sky blue?"}}
                    }
            };
            return Json(jsonData);
        }

        [AcceptGet()]
        public ActionResult Catalog()
        {
            var products = _productRepository.GetAll();
            return View(products.ToProductListingModel());
        }

    }

    public class JQGridRequestModel
    {
        public string sidx { get; set; }
        public string sord { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
    }
}