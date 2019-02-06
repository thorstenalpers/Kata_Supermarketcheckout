namespace SupermarketCheckout.API.V1.Models
{
    /// <summary>
    /// The bill for the checkout
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// The price to pay
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
