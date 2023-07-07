using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseFromId { get; set; }
        public int WarehouseToId { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
        public int DocumentNo { get; set; }
    }
}
