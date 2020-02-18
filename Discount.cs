using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountSystem_ECommerce
{
    public class PercentageDiscount : IDiscount
    {
        public PercentageDiscount(decimal percentDiscount)
        {
            PercentDiscount = percentDiscount;
        }
        public decimal PercentDiscount { get; }
        string _discountDescr;
        string IDiscount.DiscountDescription { get => _discountDescr; set => _discountDescr = "Percentage Discount"; }



        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            var totalPrice = productPrice * quantity;
            return totalPrice - (totalPrice * PercentDiscount/100);
        }
    }
    public class FixPriceDiscount : IDiscount
    {
        public decimal PriceDiscount { get; set; }

        public FixPriceDiscount(decimal priceDiscount)
        {
            PriceDiscount = priceDiscount;
        }
        string _discountDescr;
        string IDiscount.DiscountDescription { get => _discountDescr; set => _discountDescr = "Fixed Price Discount"; }
        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            var totalPrice = productPrice * quantity;
            return totalPrice - PriceDiscount;
        }
    }

    public class BuyXGetYDiscount : IDiscount
    {
        public decimal PriceDiscount { get; set; }

        public BuyXGetYDiscount(decimal priceDiscount)
        {
            PriceDiscount = priceDiscount;
        }
        string _discountDescr;
        string IDiscount.DiscountDescription { get => _discountDescr; set => _discountDescr = "BuyX GetY Discount"; }

        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            //Future implementation
            return productPrice;
        }
    }
    public class BuyXForYDiscount : IDiscount
    {
        public decimal PriceDiscount { get; set; }

        public BuyXForYDiscount(int buyX, int forY, decimal priceDiscount)
        {
            PriceDiscount = priceDiscount;
        }
        string _discountDescr;
        string IDiscount.DiscountDescription { get => _discountDescr; set => _discountDescr = "BuyXForY Discount"; }
        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            //Future implementation
            return productPrice;
        }
    }
}
