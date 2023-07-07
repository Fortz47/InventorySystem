using InventorySystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<StockIn> StockIn { get; set; }
        public DbSet<StockLevel> StockLevel { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseProduct> WarehouseProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasData(
                new Users {Id = 1, Name = "Fortune", Email = "atuokwu.fortune@gmail.com", Phone = 8186593330, Password = "Fort47", UserType = "Admin" }
                );
        }
    }
}
