using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models.VMs
{
    public class StockMovementVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string WarehouseFromName { get; set; }
        public string WarehouseToName { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
        public int DocumentNo { get; set; }
    }
}
