using SupermarketCheckout.Common.Model;
using SupermarketCheckout.Contracts;
using SupermarketCheckout.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketCheckout.Services
{
    public class SupermarketBasketFactory : ISupermarketBasketFactory
    {
        private Dictionary<EArticle, uint> CreateShoppingBasket(IList<EArticle> articles)
        {
            var shoppingBasket = new Dictionary<EArticle, uint>();
            if (articles == null || !articles.Any())
                throw new System.Exception("Cant create a shopping basket of an empty list of items");

            foreach (var item in articles)
            {
                if (!shoppingBasket.ContainsKey(item))
                {
                    shoppingBasket.Add(item, 1);
                }
                else
                {
                    shoppingBasket[item] += 1;
                }
            }
            return shoppingBasket;
        }

        public Basket Create(IList<EArticle> articles)
        {
            return new Basket
            {
                MapArticlesToNumber = CreateShoppingBasket(articles)
            };
        }
    }
}
