using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscountSystem_ECommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            IList<Products> objProducts = new List<Products>();
            Products objProd1 = new Products()
            {
                Name = "Apple iPhone XR (64GB) - Blue",
                Description = "6.1-inch Liquid Retina display (LCD)",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51n24DedexL._SL1024_.jpg",
                Price = 450,
                ProductId = 1,

            };
            objProd1.discounts.Add(new PercentageDiscount(10));
            objProducts.Add(objProd1);
            objProd1 = new Products()
            {
                Name = "Apple iPhone XR (64GB) - Black",
                Description = "6.1-inch Liquid Retina display (LCD)",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51n24DedexL._SL1024_.jpg",
                Price = 50,
                ProductId = 2
            };
            objProducts.Add(objProd1);
            objProd1 = new Products()
            {
                Name = "Apple iPhone XR (64GB) - White",
                Description = "6.1-inch Liquid Retina display (LCD)",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51n24DedexL._SL1024_.jpg",
                Price = 40,
                ProductId = 4
            };
            objProducts.Add(objProd1);
            return objProducts.ToArray();

        }
        [HttpPost]
        [Route("AddOrUpdateCart")]
        public  Cart AddOrUpdateCart(Cart selectedProducts)
        {
            IEnumerable<Products> obj = Get();
            var selectedProduct = obj.FirstOrDefault(x => x.Name == selectedProducts.name);
             selectedProducts.discountedPrice= ApplyDiscount(selectedProducts.ItemPrice, selectedProducts.quantity, selectedProduct.discounts);
            return selectedProducts;
        }
     

        private decimal ApplyDiscount(int price, int quantity, IList<IDiscount> discounts)
        {
            decimal discountedPrice = price;

            foreach (IDiscount discount in discounts)
            {
                discountedPrice = discount.ApplyDiscount(discountedPrice, quantity);
            }
            return discountedPrice;

        }

    }
}
