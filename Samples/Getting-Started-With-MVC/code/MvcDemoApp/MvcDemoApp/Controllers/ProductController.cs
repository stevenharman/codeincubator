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
            List<Product> viewData = repository.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Index()
        {
            List<Product> viewData = repository.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Edit(int id)
        {
            Product viewData = repository.GetProductById(id);
            RenderView("Edit", viewData);
        }

        //public void Update(int id)
        //{
        //    try
        //    {
        //        AdventureWorksDataContext db = new AdventureWorksDataContext(@"Data Source=OBI-WAN\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True");
        //        Product viewData = db.Products.Single(p => p.ProductID == id);
        //        BindingHelperExtensions.UpdateFrom(viewData, Request.Form);
        //        db.SubmitChanges();

        //        RedirectToAction("Products");
        //    }
        //    catch
        //    {
        //        RenderView("Edit", ViewData);
        //    }
        //}
    }
}
