namespace webapi.Models
{
    public class CartItem
    {
        public string ItemID { get; set; }
        public int ProductID { get; set; }
        public int UnitQuantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
