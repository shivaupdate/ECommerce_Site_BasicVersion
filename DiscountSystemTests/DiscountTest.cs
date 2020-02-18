using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountSystem_ECommerce;
using DiscountSystem_ECommerce.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace DiscountSystemTests
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void PercentageDiscountTest()
        {

            //Arrange
            string selectedProductName = "Apple iPhone XR (64GB) - Blue";
            int selectedProductNameQuantity = 2;
            var expected = 810;
            IList<Products> objProducts = new List<Products>();
            Products objProd1 = new Products()
            {
                Name = "Apple iPhone XR (64GB) - Blue",
                Description = "6.1-inch Liquid Retina display (LCD)",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51n24DedexL._SL1024_.jpg",
                Price = 450,
                ProductId = 1,

            };
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

            //Act
            var selectedProduct = objProducts.FirstOrDefault(x => x.Name == selectedProductName);

            IDiscount discount = new PercentageDiscount(10);
            var actual = discount.ApplyDiscount(selectedProduct.Price, selectedProductNameQuantity);


            //Assert

            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void FixedPriceDiscountTest()
        {

            //Arrange
            string selectedProductName = "Apple iPhone XR (64GB) - Blue";
            int selectedProductNameQuantity = 2;
            var expected = 890;
            IList<Products> objProducts = new List<Products>();
            Products objProd1 = new Products()
            {
                Name = "Apple iPhone XR (64GB) - Blue",
                Description = "6.1-inch Liquid Retina display (LCD)",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51n24DedexL._SL1024_.jpg",
                Price = 450,
                ProductId = 1,

            };
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

            //Act
            var selectedProduct = objProducts.FirstOrDefault(x => x.Name == selectedProductName);

            IDiscount discount = new FixPriceDiscount(10);
            var actual = discount.ApplyDiscount(selectedProduct.Price, selectedProductNameQuantity);


            //Assert

            Assert.AreEqual(expected, actual);


        }
    }
}
