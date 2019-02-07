namespace SupermarketCheckout.API.V2.Models
{
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Shopping Basket holds an unsorted list of articles
    /// </summary>
    public class ShoppingBasket
    {
        /// <summary>
        /// Articles in the shopping basket
        /// </summary>
        public IList<EArticle> Articles{ get; set; }
    }
}
