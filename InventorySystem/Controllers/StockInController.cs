using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class StockInController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockInController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<StockIn> objStockInList = _db.StockIn.ToList();
            List<StockInVM> stockInVMList = new List<StockInVM>();
            foreach(var stockin in objStockInList)
            {
                Warehouse? warehouseTo = _db.Warehouse.FirstOrDefault(w => w.Id == stockin.WarehouseId);
                Products? products = _db.Products.Where(p => p.Id == stockin.ProductId).FirstOrDefault();
                StockInVM stockInVM = new StockInVM
                {
                    ProductName = products.ProductName,
                    WarehouseName = warehouseTo.Name,
                    QtyIn = stockin.QtyIn,
                    DateIn = stockin.DateIn,
                    EnteredBy = stockin.EnteredBy,
                    DocumentNo = stockin.DocumentNo
                };
                stockInVMList.Add(stockInVM);
            }
            return View(stockInVMList);
        }
        public IActionResult AddStock()
        {
            var products = _db.Products.ToList();
            ViewBag.Products = products;
            var warehouses = _db.Warehouse.ToList();
            ViewBag.Warehouse = warehouses;
            return View();
        }

        [HttpPost]
        public IActionResult AddStock(StockIn obj)
        {
            if (ModelState.IsValid)
            {
                List<StockLevel> stocklevlObj = _db.StockLevel.ToList();
                List<WarehouseProduct> warehouseProductObj = _db.WarehouseProduct.ToList();
                if (stocklevlObj.Count == 0)
                {
                    StockLevel stocklevel = new()
                    {
                        QtyInStock = obj.QtyIn,
                        ProductId = obj.ProductId,
                        WarehouseId = obj.WarehouseId
                    };
                    _db.StockLevel.Add(stocklevel);
                    _db.StockIn.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                bool flag = true;
                foreach (var stock in stocklevlObj)
                {
                    if (stock.ProductId == obj.ProductId && stock.WarehouseId == obj.WarehouseId)
                    {
                        stock.QtyInStock += obj.QtyIn;
                        _db.StockLevel.Update(stock);
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    StockLevel stocklevel = new()
                    {
                        QtyInStock = obj.QtyIn,
                        ProductId = obj.ProductId,
                        WarehouseId = obj.WarehouseId
                    };
                    _db.StockLevel.Add(stocklevel);
                }

                flag = false;
                if (warehouseProductObj.Count == 0)
                    flag = true;

                if (flag == false)
                {
                    foreach (var wp in warehouseProductObj)
                    {
                        if (wp.ProductId == obj.ProductId && wp.WarehouseId == obj.WarehouseId)
                        {
                            flag = false;
                            break;
                        }
                        flag = true;
                    }
                }
                if (flag)
                {
                    WarehouseProduct warehouseProduct = new()
                    {
                        ProductId = obj.ProductId,
                        WarehouseId = obj.WarehouseId
                    };
                    _db.WarehouseProduct.Add(warehouseProduct);
                }

                _db.StockIn.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
