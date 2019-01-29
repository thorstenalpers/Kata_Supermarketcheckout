using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Contracts
{
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
