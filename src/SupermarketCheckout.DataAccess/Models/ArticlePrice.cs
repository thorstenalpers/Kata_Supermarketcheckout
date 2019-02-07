namespace SupermarketCheckout.DataAccess.Models
{
    using SupermarketCheckout.Common.Models;

    /// <summary>
    /// A price for an item / article
    /// </summary>
    public class ArticlePrice
    {
        /// <summary>
        /// Type of an item / article of a supermarket 
        /// </summary>
        public EArticle Article { get; set; }

        /// <summary>
        /// The price of an item / article of a supermarket
        /// </summary>
        public decimal Price { get; set; }
    }
}
