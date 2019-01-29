using SupermarketCheckout.Services.Model;

namespace SupermarketCheckout.Contracts
{
    /// <summary>
    /// Calculates the total price from a supermarket basket
    /// </summary>
    public interface ISupermarketCheckout
    {
        /// <summary>
        /// Creates a bill containing the total price
        /// </summary>
        /// <param name="baket">A basket of articles of the customer</param>
        /// <returns>A bill object</returns>
        Bill CreateBill(Basket baket);
    }
}
