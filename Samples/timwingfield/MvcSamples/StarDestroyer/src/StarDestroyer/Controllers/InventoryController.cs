using System.Web.Mvc;
using StarDestroyer.Core.Services;

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

            var model = Service.GetAssaultItemById(id.Value);

            return View(model);
        }
    }
}