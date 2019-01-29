using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Contracts;
using SupermarketCheckout.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Services
{
    public class SupermarketBasketFactory : ISupermarketBasketFactory
    {
        public Basket Create(IList<EArticle> articles)
        {
            return new Basket
            {
                Articles = articles
            };
        }
    }
}
