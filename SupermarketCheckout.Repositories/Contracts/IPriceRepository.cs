using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Contracts
{
    public interface IPriceRepository
    {
        IEnumerable<ArticlePrice> GetPriceList();
    }
}
