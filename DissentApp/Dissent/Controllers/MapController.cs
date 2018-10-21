using Microsoft.AspNetCore.Mvc;

namespace Dissent.Controllers
{
    public class MapController:Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("ShowMaps");
        }
    }
}
