using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models
{
    public class StockIn
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int QtyIn { get; set; }
        public DateTime DateIn { get; set; }
        public string EnteredBy { get; set; }
        public int WarehouseId { get; set; }
        public int DocumentNo { get; set; }
    }
}
