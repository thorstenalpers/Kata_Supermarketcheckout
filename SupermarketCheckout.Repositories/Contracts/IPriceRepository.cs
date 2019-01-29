using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Contracts
{
    /// <summary>
    /// Repository stores the price list
    /// </summary>
    public interface IPriceRepository
    {
        /// <summary>
        /// Gets all prices of articles
        /// </summary>
        /// <returns>list of type ArticlePrice</returns>
        IEnumerable<ArticlePrice> GetPriceList();
    }
}
