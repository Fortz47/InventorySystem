using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        [ForeignKey("ProductsId")]
        public int ProductId { get; set; }
        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
    }
}
