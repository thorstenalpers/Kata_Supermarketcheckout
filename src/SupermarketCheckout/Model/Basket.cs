using SupermarketCheckout.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Services.Model
{
    /// <summary>
    /// Wrapper containing the articles from a customer
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Stores the Items and their number in a map
        /// </summary>
        public Dictionary<EArticle, uint> MapArticlesToNumber { get; set; }
    }
}
