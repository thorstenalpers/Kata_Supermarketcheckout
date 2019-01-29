using SupermarketCheckout.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Model
{
    public class ArticlePrice
    {
        public EArticle Article { get; set; }

        public decimal Price { get; set; }
    }
}
