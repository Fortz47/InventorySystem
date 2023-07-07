using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models.VMs
{
    public class WarehouseProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
    }
}
