using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories.Base;

    public class ArticleRepository : EfRepository<Article>, IArticleRepository
    {
        public ArticleRepository(SupermarketCheckoutContext dbContext) : base(dbContext)
        {
        }
    }
}
