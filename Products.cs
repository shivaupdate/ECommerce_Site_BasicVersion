using System;
using System.Collections.Generic;

namespace DiscountSystem_ECommerce
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        public List<IDiscount> discounts = new List<IDiscount>();
        
        
    }
}
