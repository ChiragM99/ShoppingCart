using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Supplier
    {
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
