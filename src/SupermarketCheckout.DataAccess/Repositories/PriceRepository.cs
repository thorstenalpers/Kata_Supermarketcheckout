namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.Common.Models;
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

    public class PriceRepository : IPriceRepository
    {
        public IEnumerable<ArticlePrice> GetPriceList()
        {
            yield return new ArticlePrice
            {
                Article = Article.Apple,
                Price = 30
            };
            yield return new ArticlePrice
            {
                Article = Article.Banana,
                Price = 50
            };
            yield return new ArticlePrice
            {
                Article = Article.Peach,
                Price = 60
            };
        }
    }
}
