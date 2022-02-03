using Microsoft.AspNetCore.Mvc;

namespace Guia_semana1.Controllers
{
    public class PrimeroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int primero, int segundo)
        {

            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
