namespace SupermarketCheckout.BusinessLogic.Models
{
    /// <summary>
    /// The bill for the checkout
    /// </summary>
    public class BillDto
    {
        /// <summary>
        /// The price to pay
        /// </summary>
        public decimal? TotalPrice { get; set; }
    }
}
