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

        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            var totalPrice = productPrice * quantity;
            return totalPrice - (totalPrice * PercentDiscount);
        }
    }
    public class FixPriceDiscount : IDiscount
    {
        public decimal PriceDiscount { get; set; }

        public FixPriceDiscount(decimal priceDiscount)
        {
            PriceDiscount = priceDiscount;
        }

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

        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            var totalPrice = productPrice * quantity;
            return totalPrice - PriceDiscount;
        }
    }
    public class BuyXForYDiscount : IDiscount
    {
        public decimal PriceDiscount { get; set; }

        public BuyXForYDiscount(int buyX, int forY, decimal priceDiscount)
        {
            PriceDiscount = priceDiscount;
        }

        public decimal ApplyDiscount(decimal productPrice, int quantity)
        {
            var qualifiedDiscountQuantity = quantity;
            return qualifiedDiscountQuantity - PriceDiscount;
        }
    }
}
