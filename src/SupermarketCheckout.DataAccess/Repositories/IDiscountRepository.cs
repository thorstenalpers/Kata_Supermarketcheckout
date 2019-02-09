﻿namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories.Base;

    public interface IDiscountRepository : IAsyncRepository<ArticleDiscount>
    {
    }
}
