using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Controllers
{
    public class WarehouseProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WarehouseProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<WarehouseProduct> warehouseProducts = _db.WarehouseProduct.ToList();
            List<WarehouseProductVM> warehouseProductsList = new List<WarehouseProductVM>();
            foreach (var warehouseProduct in warehouseProducts)
            {
                Warehouse? warehouse = _db.Warehouse.FirstOrDefault(w => w.Id == warehouseProduct.WarehouseId);
                Products? products = _db.Products.FirstOrDefault(p => p.Id ==  warehouseProduct.ProductId);
                WarehouseProductVM warehouseProductVM = new WarehouseProductVM
                {
                    ProductName = products.ProductName,
                    WarehouseName = warehouse.Name
                };
                warehouseProductsList.Add(warehouseProductVM);
            }
            return View(warehouseProductsList);
        }

        //public IActionResult Create()
        //{
        //    var products = _db.Products.ToList();
        //    ViewBag.Products = products;
        //    var warehouses = _db.Warehouse.ToList();
        //    ViewBag.Warehouse = warehouses;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(WarehouseProduct obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.WarehouseProduct.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();
        //    WarehouseProduct? WarehouseProductIdFromDb = _db.WarehouseProduct.FirstOrDefault(x => x.Id == id);
        //    if (WarehouseProductIdFromDb == null)
        //        return NotFound();

        //    var products = _db.Products.ToList();
        //    ViewBag.Products = products;
        //    var warehouses = _db.Warehouse.ToList();
        //    ViewBag.Warehouse = warehouses;

        //    return View(WarehouseProductIdFromDb);
        //}

        //[HttpPost]
        //public IActionResult Edit(WarehouseProduct obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.WarehouseProduct.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();
        //    WarehouseProduct? WarehouseProductIdFromDb = _db.WarehouseProduct.Find(id);
        //    if (WarehouseProductIdFromDb == null)
        //        return NotFound();
        //    return View(WarehouseProductIdFromDb);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();
        //    WarehouseProduct? WarehouseProductObj = _db.WarehouseProduct.Find(id);
        //    if (WarehouseProductObj == null)
        //        return NotFound();
        //    _db.Remove(WarehouseProductObj);
        //    _db.SaveChanges();
        //    return RedirectToAction("index");
        //}
    }
}
