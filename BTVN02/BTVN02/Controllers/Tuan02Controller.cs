using Microsoft.AspNetCore.Mvc;

namespace BTVN02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Hoten = "Nguyen Trung Hieu";
            ViewBag.MSSV = "1822040136";
            ViewBag.Nam = "2024";
            return View();
        }
    }
}
