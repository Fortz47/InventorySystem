using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserType { get; set; }
        public Users()
        {
            UserType = "User";
        }
    }
}
