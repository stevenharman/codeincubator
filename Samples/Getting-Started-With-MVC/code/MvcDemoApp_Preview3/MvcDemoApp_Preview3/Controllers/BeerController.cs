using System;
using System.Web.Mvc;
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
    }
}