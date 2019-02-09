namespace SupermarketCheckout.WebAPI.V1.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representation of a supermarket article
    /// </summary>
    public class Article 
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Required]
        public int? Id { get; set; }

        /// <summary>
        /// Name of the article
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
