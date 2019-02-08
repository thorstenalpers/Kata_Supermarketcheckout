namespace SupermarketCheckout.BusinessLogic.Models
{
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;
    
    #pragma warning disable CA2227

    /// <summary>
    /// Wrapper containing the articles from a customer
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Holds the articles and its amount in a map
        /// </summary>
        public Dictionary<Article, uint> MapArticlesToAmount { get; set; }
    }
}
