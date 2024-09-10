using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (model.Username != null)
            {
                return Content(model.Username);
            }

            return View();

        }
        public IActionResult Baitap02()
        {
            {
                var sanpham = new SanPhamViewModel()
                {
                    TenSanPham = "cà phê",
                    
                  
                };
                return View(sanpham);
            }
        }
    }
}