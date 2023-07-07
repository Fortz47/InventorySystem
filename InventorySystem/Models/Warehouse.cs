using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public  long Phone { get; set; }
        public string Email { get; set; }
    }
}
