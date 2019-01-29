using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Contracts
{
    public interface IDiscountRepository
    {
        IEnumerable<ArticleDiscount> GetDiscountList();
    }
}
