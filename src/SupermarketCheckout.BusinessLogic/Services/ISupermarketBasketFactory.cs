namespace SupermarketCheckout.BusinessLogic.Services
{
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;
    
    /// <summary>
    /// Factory creates a Basket
    /// </summary>
    public interface ISupermarketBasketFactory
    {
        /// <summary>
        /// Creates a Basket
        /// </summary>
        /// <param name="articles">An unsorted List of articles</param>
        /// <returns>An instance of an supermarket basket</returns>
        Basket Create(IList<EArticle> articles);
    }
}
