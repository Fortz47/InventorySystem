namespace InventorySystem.Models.VMs
{
    public class ProductsVM
    {
      
        public int Id { get; set; }
       
        public string ProductName { get; set; }
        
        public DateTime MFD { get; set; }
     
        public DateTime ExpDate { get; set; }
     
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
