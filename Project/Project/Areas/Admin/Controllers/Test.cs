using Microsoft.AspNetCore.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
