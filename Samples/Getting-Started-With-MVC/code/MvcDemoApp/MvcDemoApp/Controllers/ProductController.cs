using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            RenderView("Edit", viewData); 
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

        #region AJAX Demo Views

        public void Categories()
        {
            var viewData = repository.GetAllProductCategories();
            RenderView("Categories", viewData);
        }

        public void ProductsByCategory(int id)
        {
            var products = repository.GetProductsByCategory(id);
            Response.Write(MakeProductTable(products));
        }

        #endregion

        #region helper methods

        private string MakeProductTable(IEnumerable<Product> products)
        {
            var sb = new StringBuilder();
            sb.Append("<table width=\"400\" cellpadding=\"4\" cellspacing=\"0\" border=\"1\">");
            sb.Append("<tr>")
                .Append(MakeCell("Name"))
                .Append(MakeCell("Units in Stock"))
                .Append(MakeCell("List Price"))
                .Append("</tr>");

            foreach(var p in products)
            {
                sb.Append("<tr>")
                    .Append(MakeCell(p.ProductName))
                    .Append(MakeCell(p.UnitsInStock.ToString()))
                    .Append(MakeCell(p.UnitPrice.ToString()))
                    .Append("</tr>");
            }

            return sb.ToString();
        }

        private static string MakeCell(string cellContents)
        {
            var sb = new StringBuilder();
            sb.Append("<td>")
            .Append(cellContents)
            .Append("</td>");
            return sb.ToString();
        }

        #endregion
    }
}
