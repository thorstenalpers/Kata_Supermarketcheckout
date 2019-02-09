using System;

namespace SupermarketCheckout.BusinessLogic.Models
{    
    /// <summary>
    /// A price for an item / article
    /// </summary>
    public class ArticlePriceDto : IEquatable<ArticlePriceDto>
    {
        public int? Id { get; set; }

        /// <summary>
        /// Type of an item / article of a supermarket 
        /// </summary>
        public ArticleDto Article { get; set; }

        /// <summary>
        /// The price of an item / article of a supermarket
        /// </summary>
        public decimal? UnitPrice { get; set; }

        public bool Equals(ArticlePriceDto other)
        {
            if (other == null) return false;
            return other.Article.Equals(this.Article) &&
                other.Id == this.Id &&
                other.UnitPrice == this.UnitPrice;
        }

        public override bool Equals(object obj)
        {
            var obj2 = (ArticlePriceDto) obj;

            return Equals(obj as ArticlePriceDto);
        }

        public override int GetHashCode()
        {
            // don't use GetHashCode
            return 0;
        }
    }
}
