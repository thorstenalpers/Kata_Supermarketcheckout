﻿namespace SupermarketCheckout.BusinessLogic.Services
{
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.Common.Models;

    /// <summary>
    /// Calculates the total price from a supermarket basket
    /// </summary>
    public interface ISupermarketCheckoutService
    {
        /// <summary>
        /// Creates a bill containing the total price
        /// </summary>
        /// <param name="baket">A basket of articles of the customer</param>
        /// <returns>A bill object</returns>
        Bill CreateBill(ShoppingCart baket);
    }
}
