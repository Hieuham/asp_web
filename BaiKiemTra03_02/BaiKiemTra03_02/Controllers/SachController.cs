using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_02.Controllers
{
    [Area("Admin")]
    public class SachController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SachController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> book = _db.Book.Include("Author").ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Book book = new Book();
            IEnumerable<SelectListItem> dsSach = _db.Book.Select(
               item => new SelectListItem
               {
                   Value = item.book_Id.ToString(),
                   Text = item.Title
               });
            ViewBag.DSBook = dsSach;
            if (id == 0)
            {
                return View(book);
            }
            else
            {
                book = _db.Book.Include("Author").FirstOrDefault(sp => sp.book_Id == id);
                return View(book);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Book sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.book_Id == 0)
                {
                    _db.Book.Add(sanpham);
                }
                else
                {
                    _db.Book.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            var sanpham = _db.Book.FirstOrDefault(sp => sp.book_Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.Book.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });

        }
    }
}
