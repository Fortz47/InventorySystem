using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models.VMs;

namespace InventorySystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<UsersVM> objUsersList = _db.Users.Select(u => new UsersVM
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                WarehouseId = u.WarehouseId,
                Password = u.Password,
                warehouse = _db.Warehouse.FirstOrDefault(w => w.Id == u.WarehouseId)
            }).ToList();
            return View(objUsersList);

            //List<Users> users = _db.Users.ToList();
            //List<UsersVM> usersVMs = new List<UsersVM>();
            //foreach(var user in users)
            //{
            //    Warehouse? warehouse = _db.Warehouse.Find(user.WarehouseId);
            //    UsersVM usersVM = new UsersVM
            //    {
            //        Name = user.Name,
            //        Email = user.Email,
            //        Phone = user.Phone,
            //        WarehouseName = warehouse.Name
            //    };
            //    usersVMs.Add(usersVM);
            //}
            //return View(usersVMs);
        }
        public IActionResult Create()
        {
            var warehouse = _db.Warehouse.ToList();
            ViewBag.Warehouse = warehouse;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Users? UsersIdFromDb = _db.Users.FirstOrDefault(x => x.Id == id);
            if (UsersIdFromDb == null)
                return NotFound();
            return View(UsersIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Users? UsersIdFromDb = _db.Users.Find(id);
            if (UsersIdFromDb == null)
                return NotFound();
            return View(UsersIdFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Users? UsersObj = _db.Users.Find(id);
            if (UsersObj == null)
                return NotFound();
            _db.Remove(UsersObj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
