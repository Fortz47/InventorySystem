using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models.VMs
{
    public class StockInVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int QtyIn { get; set; }
        public DateTime DateIn { get; set; }
        public string EnteredBy { get; set; }
        public string WarehouseName { get; set; }
        public int DocumentNo { get; set; }
    }
}
