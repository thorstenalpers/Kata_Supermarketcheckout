namespace SupermarketCheckout.DataAccess.Models
{
    using SupermarketCheckout.Common.Models;

    /// <summary>
    /// Model holds the discount information about an article
    /// </summary>
    /// <example>
    /// Banana costs 50 per unit, 
    /// if you buy 3 you could get them for 130
    /// NewPrice = 130
    /// NumberOfArticles = 3
    /// </example>
    public class ArticleDiscount
    {
        /// <summary>
        /// supermarket article
        /// </summary>
        public EArticle Article { get; set; }

        /// <summary>
        /// exact number of articles to get the NewPrice  
        /// </summary>
        public uint NumberOfArticles { get; set; }

        /// <summary>
        /// the new price for the NumberOfArticles
        /// </summary>
        public decimal NewPrice { get; set; }
    }
}
