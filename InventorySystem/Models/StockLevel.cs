using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class StockLevel
    {
        [Key]
        public int Id { get; set; }
        public int QtyInStock { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
    }
}
