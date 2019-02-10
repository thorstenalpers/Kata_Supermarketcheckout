namespace SupermarketCheckout.DataAccess.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representation of a supermarket article
    /// </summary>
    public class Article : BaseEntity
    {
        public string Name { get; set; }
    }
}
