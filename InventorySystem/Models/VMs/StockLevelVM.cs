namespace InventorySystem.Models.VMs
{
    public class StockLevelVM
    {
        public int Id { get; set; }
        public int QtyInStock { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
    }
}
