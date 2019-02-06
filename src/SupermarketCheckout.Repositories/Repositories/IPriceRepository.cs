namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

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
