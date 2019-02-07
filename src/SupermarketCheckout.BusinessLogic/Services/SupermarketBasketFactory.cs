namespace SupermarketCheckout.BusinessLogic.Services
{
    using SupermarketCheckout.BusinessLogic.Models;
    using SupermarketCheckout.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Concrete factory which creates a supermarket basket
    /// </summary>
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

        /// <inheritdoc />
        public Basket Create(IList<EArticle> articles)
        {
            return new Basket
            {
                MapArticlesToCount = CreateShoppingBasket(articles)
            };
        }
    }
}
