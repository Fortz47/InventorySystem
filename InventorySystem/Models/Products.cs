 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public DateTime MFD { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    
    }
}
