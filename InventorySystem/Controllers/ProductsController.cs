using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //List<ProductsCategoriesVM> objProductsList = _db.Categories.Select(n => new ProductsCategoriesVM
            //{
            //    Id = n.Id,
            //    CategoryName = n.CategoryName,
            //    products = _db.Products.Where(p => p.CategoryId == n.Id).Select(pr => new Products
            //    {
            //        ProductName = pr.ProductName


            //    }).ToList()

            //}).ToList();

            List<ProductsVM> objProductsList = _db.Products.Select(n => new ProductsVM
            {
                Id = n.Id,
                ProductName = n.ProductName,
                MFD = n.MFD,
                ExpDate = n.ExpDate,
                CategoryId = n.CategoryId,
                category = _db.Categories.FirstOrDefault(c => c.Id == n.CategoryId)

            }).ToList();

            return View(objProductsList);
        }

        public IActionResult Create()
        {
            List<Category> cat = _db.Categories.ToList();
            ViewBag.Categories = cat;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Products? ProductsIdFromDb = _db.Products.FirstOrDefault(x => x.Id == id);
            if (ProductsIdFromDb == null)
                return NotFound();

            var cat = _db.Categories.ToList();
            ViewBag.Categories = cat;

            return View(ProductsIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Products? ProductsIdFromDb = _db.Products.Find(id);
            if (ProductsIdFromDb == null)
                return NotFound();
            return View(ProductsIdFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Products? ProductsObj = _db.Products.Find(id);
            if (ProductsObj == null)
                return NotFound();
            _db.Remove(ProductsObj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
