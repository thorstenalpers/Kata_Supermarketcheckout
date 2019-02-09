using System.ComponentModel.DataAnnotations;

namespace SupermarketCheckout.WebAPI.V1.Models
{
    /// <summary>
    /// The bill for the checkout
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// The price to pay
        /// </summary>
        [Required]
        public decimal? TotalPrice { get; set; }
    }
}
