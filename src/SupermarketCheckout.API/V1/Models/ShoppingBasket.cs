namespace SupermarketCheckout.API.V1.Models
{
    using SupermarketCheckout.Common.Models;
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
        public IList<Article> Articles { get; set; }
    }
}
