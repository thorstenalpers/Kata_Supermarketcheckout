namespace SupermarketCheckout.WebAPI.V1.Models
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// A price for an item / article
    /// </summary>
    public class ArticlePrice
    {
        /// <summary>
        /// identifier
        /// </summary>
        [Required]
        public int? Id { get; set; }

        /// <summary>
        /// Type of an item / article of a supermarket 
        /// </summary>
        [Required]
        public Article Article { get; set; }

        /// <summary>
        /// The price of an item / article of a supermarket
        /// </summary>
        [Required]
        public decimal? UnitPrice { get; set; }
    }
}
