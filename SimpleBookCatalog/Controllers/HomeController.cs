using Microsoft.AspNetCore.Mvc;

namespace SimpleBookCatalog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
