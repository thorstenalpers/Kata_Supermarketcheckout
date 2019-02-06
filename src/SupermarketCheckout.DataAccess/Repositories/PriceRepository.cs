namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

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
