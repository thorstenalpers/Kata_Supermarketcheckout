namespace SupermarketCheckout.BusinessLogic.Models
{
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Wrapper containing the articles from a customer
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Stores the articles and their counts in a map
        /// </summary>
        public Dictionary<EArticle, uint> MapArticlesToCount { get; set; }
    }
}
