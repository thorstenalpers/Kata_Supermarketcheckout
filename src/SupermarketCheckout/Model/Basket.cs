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
        /// The articles which a customer wants to buy
        /// </summary>
        public IList<EArticle> Articles { get; set; }
    }
}
