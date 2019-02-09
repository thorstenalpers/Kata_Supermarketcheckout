namespace SupermarketCheckout.DataAccess.Models
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// A price for an item / article
    /// </summary>
    public class ArticlePrice : BaseEntity
    {
        /// <summary>
        /// Type of an item / article of a supermarket 
        /// </summary>
        public virtual Article Article { get; set; }

        [Required]
        public int ArticleId { get; set; }

        /// <summary>
        /// The price of an item / article of a supermarket
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
