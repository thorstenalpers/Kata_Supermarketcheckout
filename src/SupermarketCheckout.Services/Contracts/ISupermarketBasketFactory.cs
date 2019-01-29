using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Services.Model;
using System.Collections.Generic;

namespace SupermarketCheckout.Contracts
{
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
