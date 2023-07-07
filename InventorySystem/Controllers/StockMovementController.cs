using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockMovementController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<StockMovement> stockMovement = _db.StockMovement.ToList();
            List<StockMovementVM> objStockMovementList = new List<StockMovementVM>();
            foreach (var stock in stockMovement)
            {
                Warehouse? warehouseFrom = _db.Warehouse.FirstOrDefault(w => w.Id == stock.WarehouseFromId);
                Warehouse? warehouseTo = _db.Warehouse.FirstOrDefault(w => w.Id == stock.WarehouseToId);
                Products? products = _db.Products.Where(p => p.Id == stock.ProductId).FirstOrDefault();
                StockMovementVM objStockMovement = new StockMovementVM
                {
                    ProductName = products.ProductName,
                    WarehouseFromName = warehouseFrom.Name,
                    WarehouseToName = warehouseTo.Name,
                    Qty = stock.Qty,
                    Date = stock.Date,
                    DocumentNo = stock.DocumentNo
                };
                objStockMovementList.Add(objStockMovement);
            }
            
            return View(objStockMovementList);
        }
        public IActionResult MoveStock()
        {
            var products = _db.Products.ToList();
            ViewBag.Products = products;
            var warehouses = _db.Warehouse.ToList();
            ViewBag.Warehouse = warehouses;
            return View();
        }

        [HttpPost]
        public IActionResult MoveStock(StockMovement obj)
        {
            if (ModelState.IsValid)
            {
                List<StockLevel> stocklevlObj = _db.StockLevel.ToList();
                List<WarehouseProduct> warehouseProductObj = _db.WarehouseProduct.ToList();
                if (stocklevlObj.Count == 0)
                {
                    ModelState.AddModelError("WarehouseFromId", "Warehouse has no Product");
                    return View();
                }
                int flag = 0;
                foreach (var warehouseProduct in warehouseProductObj)
                {
                    if (obj.WarehouseFromId == warehouseProduct.WarehouseId && obj.ProductId == warehouseProduct.ProductId)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    foreach (var stock in stocklevlObj)
                    {
                        if (stock.ProductId == obj.ProductId && stock.WarehouseId == obj.WarehouseFromId)
                        {
                            if (obj.Qty > stock.QtyInStock)
                                ModelState.AddModelError("WarehouseFromId", "Insufficient Product");
                            stock.QtyInStock -= obj.Qty;
                            if (stock.QtyInStock == 0)
                            {
                                foreach (var wp in warehouseProductObj)
                                {
                                    if (wp.ProductId == obj.ProductId && wp.WarehouseId == obj.WarehouseFromId)
                                    {
                                        _db.WarehouseProduct.Remove(wp);
                                        break;
                                    }
                                }
                            }

                            _db.StockLevel.Update(stock);
                            break;
                        }
                    }
                    flag = 0;
                    foreach (var stock in stocklevlObj)
                    {
                        if (stock.WarehouseId == obj.WarehouseToId && stock.ProductId == obj.ProductId)
                        {
                            stock.QtyInStock += obj.Qty;
                            _db.StockLevel.Update(stock);
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        StockLevel stocklevel = new()
                        {
                            QtyInStock = obj.Qty,
                            ProductId = obj.ProductId,
                            WarehouseId = obj.WarehouseToId
                        };
                        _db.StockLevel.Add(stocklevel);

                        WarehouseProduct warehouseProduct = new()
                        {
                            ProductId = obj.ProductId,
                            WarehouseId = obj.WarehouseToId
                        };
                        _db.WarehouseProduct.Add(warehouseProduct);

                    }
                    _db.StockMovement.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("WarehouseFromId", "Product not in Warehouse");
            return View();
        }
    }
   
}
