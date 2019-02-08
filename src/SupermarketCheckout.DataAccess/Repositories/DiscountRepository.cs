namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.Common.Models;
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;

    public class DiscountRepository : IDiscountRepository
    {
        public IEnumerable<ArticleDiscount> GetDiscountList()
        {
            yield return new ArticleDiscount
            {
                Article = Article.Apple,
                NumberOfArticles = 2,
                NewPrice = 45
            };

            yield return new ArticleDiscount
            {
                Article = Article.Banana,
                NumberOfArticles = 3,
                NewPrice = 130
            };
        }
    }
}
