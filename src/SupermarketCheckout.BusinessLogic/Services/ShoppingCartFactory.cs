namespace SupermarketCheckout.BusinessLogic.Services
{
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Concrete factory which creates a supermarket basket
    /// </summary>
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        private Dictionary<Article, uint> CreateShoppingBasket(IList<Article> articles)
        {
            var shoppingBasket = new Dictionary<Article, uint>();
            if (articles == null || !articles.Any())
                throw new ArgumentNullException(nameof(articles), "Cant create a shopping basket of an empty list of articles");

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

        /// <inheritdoc />
        public ShoppingCart Create(IList<Article> articles)
        {
            return new ShoppingCart
            {
                MapArticlesToAmount = CreateShoppingBasket(articles)
            };
        }
    }
}
