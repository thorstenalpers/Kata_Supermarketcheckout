using SupermarketCheckout.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Repositories.Model
{
    public class ArticleDiscount
    {
        public EArticle Article { get; set; }

        public uint NumberOfItems { get; set; }

        public decimal NewPrice { get; set; }
    }
}
