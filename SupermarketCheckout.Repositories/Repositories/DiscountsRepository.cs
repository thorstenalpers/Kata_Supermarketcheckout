using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Repositories.Contracts;
using SupermarketCheckout.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Repositories
{
    public class DiscountsRepository : IDiscountRepository
    {
        public IEnumerable<ArticleDiscount> GetDiscountList()
        {
            yield return new ArticleDiscount
            {
                Article = EArticle.Apple,
                NumberOfItems = 2,
                NewPrice = 45
            };

            yield return new ArticleDiscount
            {
                Article = EArticle.Banana,
                NumberOfItems = 3,
                NewPrice = 130
            };
        }
    }
}
