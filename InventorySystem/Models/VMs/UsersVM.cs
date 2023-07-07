using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models.VMs
{
    public class UsersVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int WarehouseId { get; set; }
        //public String WarehouseName { get; set; }
        public Warehouse warehouse { get; set; }
        public string Password { get; set; }
    }
}
