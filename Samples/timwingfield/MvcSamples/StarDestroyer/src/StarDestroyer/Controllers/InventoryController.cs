using System.Web.Mvc;
using MvcContrib.Attributes;
using StarDestroyer.Core.Services;
using StarDestroyer.Models;

namespace StarDestroyer.Controllers
{
    public class InventoryController : Controller
    {
        public IInventoryService Service { get; private set; }

        public InventoryController() : this(null) { }

        public InventoryController(IInventoryService service)
        {
            Service = service ?? new InventoryService();
        }

        public ViewResult Index()
        {
            var model = Service.GetAllAssaultItems();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = Service.GetAssaultItemById(id.Value).ToDetailModel();

            return View(model);
        }

        [AcceptGet]
        public ActionResult AjaxDetails(int? id)
        {
            return View();
        }
    }
}