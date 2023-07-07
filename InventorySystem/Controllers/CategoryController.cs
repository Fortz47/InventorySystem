using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? CategoryIdFromDb = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (CategoryIdFromDb == null)
                return NotFound();
            return View(CategoryIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? CategoryIdFromDb = _db.Categories.Find(id);
            if (CategoryIdFromDb == null)
                return NotFound();
            return View(CategoryIdFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? CategoryObj = _db.Categories.Find(id);
            if (CategoryObj == null)
                return NotFound();
            _db.Remove(CategoryObj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
