﻿namespace DiscountSystem_ECommerce
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal productPrice, int Quantity);
        string DiscountDescription { get; set; }
    }
}