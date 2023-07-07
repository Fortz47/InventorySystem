using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models.VMs
{
    public class ProductsCategoriesVM
    {


        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Products> products { get; set; }
    }
}
