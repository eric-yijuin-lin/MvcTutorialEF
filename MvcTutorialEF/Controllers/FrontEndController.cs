using Microsoft.AspNetCore.Mvc;

namespace MvcTutorialEF.Controllers
{
    public class FrontEndController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
