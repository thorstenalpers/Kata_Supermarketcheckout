using SupermarketCheckout.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.BusinessLogic.Services
{
    public interface ISupermarketStoreService
    {
        Task<IReadOnlyList<ArticleDto>> GetAllArticles();

        Task<IReadOnlyList<ArticleDiscountDto>> GetAllDiscounts();

        Task<IReadOnlyList<ArticlePriceDto>> GetAllPrices();
    }
}
