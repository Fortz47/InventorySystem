using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WarehouseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Warehouse> objWarehouseList = _db.Warehouse.ToList();
            return View(objWarehouseList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Warehouse obj)
        {
            if (ModelState.IsValid)
            {
                _db.Warehouse.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Warehouse? WarehouseIdFromDb = _db.Warehouse.FirstOrDefault(x => x.Id == id);
            if (WarehouseIdFromDb == null)
                return NotFound();
            return View(WarehouseIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Warehouse obj)
        {
            if (ModelState.IsValid)
            {
                _db.Warehouse.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Warehouse? WarehouseIdFromDb = _db.Warehouse.Find(id);
            if (WarehouseIdFromDb == null)
                return NotFound();
            return View(WarehouseIdFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Warehouse? WarehouseObj = _db.Warehouse.Find(id);
            if (WarehouseObj == null)
                return NotFound();
            _db.Remove(WarehouseObj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
