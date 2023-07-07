using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContext;
        public HomeController(ApplicationDbContext db, IHttpContextAccessor httpContext)
        {
            _db = db;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            Users user = new Users();
            return View(user);
        }
        [HttpPost]
        public IActionResult Index(Users systemUser)
        {
            var validateUser = _db.Users.Where(n => n.Name == systemUser.Name && n.Password == systemUser.Password && n.UserType == "User").FirstOrDefault();
            var validateAdmin = _db.Users.Where(n => n.Name == systemUser.Name && n.Password == systemUser.Password && n.UserType == "Admin").FirstOrDefault();
            if (validateAdmin == null && validateUser == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else if (validateUser != null)
            {
                _httpContext.HttpContext.Session.SetInt32("Warehouse", validateUser.WarehouseId);
                _httpContext.HttpContext.Session.SetString("User", validateUser.Name);
                return RedirectToAction("UserMenu");
            }
            else if (validateAdmin != null)
            {
                _httpContext.HttpContext.Session.SetString("Admin", validateAdmin.Name);
                return RedirectToAction("AdminMenu");
            }
            return View(systemUser);
        }
        public IActionResult AdminMenu()
        {
            return View();
        }
        public IActionResult UserMenu()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}