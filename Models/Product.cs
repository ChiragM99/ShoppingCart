using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; 
        [Required]}
        public int CategoryID { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public double UnitPrice { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }


    }
}
