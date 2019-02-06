namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

    /// <summary>
    /// A Repository which holds information about article discounts
    /// </summary>
    public interface IDiscountRepository
    {
        /// <summary>
        /// Retrieves a list of article discounts
        /// </summary>
        /// <returns>A list of article discounts</returns>
        IEnumerable<ArticleDiscount> GetDiscountList();
    }
}
