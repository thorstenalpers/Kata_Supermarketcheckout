namespace SupermarketCheckout.BusinessLogic.Models
{
    using System.Collections.Generic;

    #pragma warning disable CA2227

    /// <summary>
    /// Shopping Basket holds an unsorted list of articles
    /// </summary>
    public class ShoppingBasketDto
    {
        /// <summary>
        /// Articles in the shopping basket
        /// </summary>
        public IList<BasketItemDto> Articles { get; set; }
    }
}
