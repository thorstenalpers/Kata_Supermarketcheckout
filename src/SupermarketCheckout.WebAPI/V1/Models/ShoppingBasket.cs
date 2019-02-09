namespace SupermarketCheckout.WebAPI.V1.Models
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

    #pragma warning disable CA2227

    /// <summary>
    /// Shopping Basket holds an unsorted list of articles
    /// </summary>
    public class ShoppingBasket
    {
        /// <summary>
        /// Articles in the shopping basket
        /// </summary>
        public IList<BasketItem> Articles { get; set; }
    }
}
