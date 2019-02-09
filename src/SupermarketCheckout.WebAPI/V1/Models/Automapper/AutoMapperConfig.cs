using AutoMapper;
using SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketCheckout.WebAPI.V1.Models.Automapper
{
    /// <summary>
    /// The mapping configuration
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        ///  registers all mapping profiles
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Reset();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ArticleDiscountProfile>();
                cfg.AddProfile<ArticlePriceProfile>();
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<BasketItemProfile>();
                cfg.AddProfile<BillProfile>();
                cfg.AddProfile<ShoppingBasketProfile>();
            });
        }
    }
}
