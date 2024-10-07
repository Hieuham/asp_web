using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_02.Controllers
{
    [Area("Admin")]
    public class TacGiaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TacGiaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var author = _db.Author.ToList();
            ViewBag.Author = author;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                
                _db.Author.Add(author);
              
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Author.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                
                _db.Author.Update(author);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Author.Find(id);
            return View(author);
        }


        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var author = _db.Author.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Author.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Author.Find(id);
            return View(author);
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var author = _db.Author
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
                ViewBag.TheLoai = author;
            }
            else
            {
                var author = _db.Author.ToList();
                ViewBag.author = author;
            }
            return View("Index");

        }
    }
}
