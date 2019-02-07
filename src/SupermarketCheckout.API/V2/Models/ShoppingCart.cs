namespace SupermarketCheckout.API.V2.Models
{
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Shopping Cart holds the items of articles
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Items in the shopping cart
        /// </summary>
        public IList<EArticle> Items{ get; set; }
    }
}
