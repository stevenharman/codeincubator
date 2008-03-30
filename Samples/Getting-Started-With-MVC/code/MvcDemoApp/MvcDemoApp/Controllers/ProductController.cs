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
        public void Products()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext(@"Data Source=OBI-WAN\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True");
            List<Product> viewData = db.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Index()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext(@"Data Source=OBI-WAN\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True");
            List<Product> viewData = db.GetTenProducts();
            RenderView("Products", viewData);
        }

        public void Edit(int id)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext(@"Data Source=OBI-WAN\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True");
            Product viewData = db.GetProductById(id);
            RenderView("Edit", viewData);
        }

        public void Update(int id)
        {
            try
            {
                AdventureWorksDataContext db = new AdventureWorksDataContext(@"Data Source=OBI-WAN\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True");
                Product viewData = db.Products.Single(p => p.ProductID == id);
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
