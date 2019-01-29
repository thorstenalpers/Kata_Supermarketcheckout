using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Repositories.Contracts;
using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        public IEnumerable<ArticlePrice> GetPriceList()
        {
            yield return new ArticlePrice
            {
                Article = EArticle.Apple,
                Price = 30
            };
            yield return new ArticlePrice
            {
                Article = EArticle.Banana,
                Price = 50
            };
            yield return new ArticlePrice
            {
                Article = EArticle.Peach,
                Price = 60
            };
        }
    }
}
