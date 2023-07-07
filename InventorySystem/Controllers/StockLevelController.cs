using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class StockLevelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockLevelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<StockLevel> stocklevelFromDb = _db.StockLevel.ToList();
            List<StockLevelVM> stockLevelVM = new List<StockLevelVM>();
            foreach(var stocklevel in  stocklevelFromDb)
            {
                Warehouse? warehouse = _db.Warehouse.FirstOrDefault(w => w.Id == stocklevel.WarehouseId);
                Products? products = _db.Products.Where(p => p.Id == stocklevel.ProductId).FirstOrDefault();
                StockLevelVM stockLevelVmObj = new StockLevelVM
                {
                    ProductName = products.ProductName,
                    WarehouseName = warehouse.Name,
                    QtyInStock = stocklevel.QtyInStock
                };
                stockLevelVM.Add(stockLevelVmObj);
            }
            return View(stockLevelVM);
        }
    }
}
