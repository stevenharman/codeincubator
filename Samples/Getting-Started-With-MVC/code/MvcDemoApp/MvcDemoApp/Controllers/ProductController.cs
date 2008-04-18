using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoApp.Models;

namespace MvcDemoApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController()
            : this(new ProductRepository())
        {
        }

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public void Products()
        {
            var viewData = repository.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Index()
        {
            var viewData = repository.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Edit(int id)
        {
            var viewData = repository.GetProductById(id);
            RenderView("Edit", viewData); //Convention over configuration
        }

        public void Update(int id)
        {
            try
            {
                var db = new NorthwindDataContext();

                var viewData = db.Products.Single(p => p.ProductID == id);
                BindingHelperExtensions.UpdateFrom(viewData, Request.Form);
                db.SubmitChanges();

                RedirectToAction("Products");
            }
            catch
            {
                RenderView("Edit", ViewData);
            }
        }
    }
}
