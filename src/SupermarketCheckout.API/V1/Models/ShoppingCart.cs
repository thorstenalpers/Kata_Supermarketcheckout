namespace SupermarketCheckout.API.V1.Models
{
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
