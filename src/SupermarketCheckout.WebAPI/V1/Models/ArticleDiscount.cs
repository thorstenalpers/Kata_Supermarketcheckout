namespace SupermarketCheckout.WebAPI.V1.Models
{
    using System.ComponentModel.DataAnnotations;

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
        /// identifier
        /// </summary>
        [Required]
        public int? Id { get; set; }

        /// <summary>
        /// supermarket article
        /// </summary>
        [Required]
        public Article Article { get; set; }

        /// <summary>
        /// exact number of articles to get the NewPrice  
        /// </summary>
        [Required]
        public int? NumberOfArticles { get; set; }

        /// <summary>
        /// the new price for the NumberOfArticles
        /// </summary>
        [Required]
        public decimal? NewPrice { get; set; }
    }
}
