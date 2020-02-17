namespace DiscountSystem_ECommerce.Controllers
{
    public class Cart
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public int ItemPrice
        {
            get; set;
        }
        public decimal discountedPrice { get; set; }
    }
}