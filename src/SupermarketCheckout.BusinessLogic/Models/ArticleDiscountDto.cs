using System;

namespace SupermarketCheckout.BusinessLogic.Models
{
    /// <summary>
    /// Model holds the discount information about an article
    /// </summary>
    /// <example>
    /// Banana costs 50 per unit, 
    /// if you buy 3 you could get them for 130
    /// NewPrice = 130
    /// NumberOfArticles = 3
    /// </example>
    public class ArticleDiscountDto : IEquatable<ArticleDiscountDto>
    {
        public int? Id { get; set; }
        
        /// <summary>
        /// supermarket article
        /// </summary>
        public ArticleDto Article { get; set; }

        /// <summary>
        /// exact number of articles to get the NewPrice  
        /// </summary>
        public int? NumberOfArticles { get; set; }

        /// <summary>
        /// the new price for the NumberOfArticles
        /// </summary>
        public decimal? NewPrice { get; set; }

        public bool Equals(ArticleDiscountDto other)
        {
            if (other == null) return false;
            return other.Article.Equals(this.Article) &&
                other.Id == this.Id &&
                other.NewPrice.HasValue && 
                this.NewPrice.HasValue &&
                Decimal.Round(other.NewPrice.Value * 100, 0) == Decimal.Round(this.NewPrice.Value * 100, 0) &&
                other.NumberOfArticles == this.NumberOfArticles;
        }

        public override bool Equals(object obj)
        {
            var obj2 = (ArticleDiscountDto)obj;

            return Equals(obj as ArticleDiscountDto);
        }

        public override int GetHashCode()
        {
            // don't use GetHashCode
            return 0;
        }
    }
}
