using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MvcDemoApp_Preview3.Models;

namespace MvcDemoApp_Preview3.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerRepository repository;

        public BeerController() 
            : this(new BeerRepository())
        {}

        public BeerController(IBeerRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index(int? id)
        {
            int numPerPage = 5;
            int page = id.HasValue && id.Value > 0 ? id.Value : 1;

            ViewData["Title"] = "Beer List";
            ViewData["TotalBeers"] = repository.GetAllBeers().Count;
            ViewData["NumberOfPages"] = UtilityMethods.PagesNeeded((int)ViewData["TotalBeers"], numPerPage);
            
            ViewData.Model = repository.GetBeersForPage(page, numPerPage);

            return View();
        }

        public ActionResult BeerPlease(int id)
        {
            Beer b = repository.GetBeerById(id);
            return Content(UtilityMethods.CreateBeerPleaseContent(b));
        }

        public ActionResult BeerDetail(int id)
        {
            return View(repository.GetBeerById(id));
        }

        public ActionResult Edit(int id)
        {
            Beer b = repository.GetBeerById(id);
            ViewData["Title"] = "Edit " + b.Name;

            //ViewData["CategoryID"] = new SelectList(repository.Categories.ToList(), "CategoryID", "CategoryName", ViewData["CategoryID"] ?? product.CategoryID);
            ViewData["Type_id"] = new SelectList(repository.GetAllBeerTypes(), "id", "Name",
                                                    ViewData["Type_id"] ?? b.Type_id);

            ViewData["Brewery_id"] = new SelectList(repository.GetAllBreweries(), "id", "Name",
                                                    ViewData["Brewery_id"] ?? b.Brewery_id);

            return View(b);
        }

        public ActionResult Update(int id)
        {
            var db = new BeerDataContext();

            Beer beer = db.Beers.SingleOrDefault(b => b.id == id);
            BindingHelperExtensions.UpdateFrom(beer, Request.Form);
            db.SubmitChanges();

            return RedirectToRoute(new RouteValueDictionary(new { Action = "Index" }));
        }
    }
}