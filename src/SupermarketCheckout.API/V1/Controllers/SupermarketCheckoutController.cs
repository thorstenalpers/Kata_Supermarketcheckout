namespace CoreAPI1.API.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using SupermarketCheckout.API.V1.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.Common.Models;

    /// <summary>
    /// Crates a checkout for a supermarket
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class SupermarketCheckoutController : Controller
    {
        readonly ISupermarketCheckoutService _supermarketCheckoutService;
        readonly IShoppingCartFactory _supermarketBasketFactory;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketCheckoutService"></param>
        /// <param name="supermarketBasketFactory"></param>
        public SupermarketCheckoutController(ISupermarketCheckoutService supermarketCheckoutService, IShoppingCartFactory supermarketBasketFactory)
        {
            _supermarketCheckoutService = supermarketCheckoutService;
            _supermarketBasketFactory = supermarketBasketFactory;
        }

        /// <summary>
        /// Creates a bill by a given shopping cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Bill> CreateBill([FromBody] ShoppingBasket cart)
        {
            if (cart == null || cart.Articles == null || !cart.Articles.Any())
                return StatusCode(StatusCodes.Status400BadRequest);

            var basket = _supermarketBasketFactory.Create(cart.Articles);
            var bill = _supermarketCheckoutService.CreateBill(basket);

            if (bill != null)
                return Ok(bill);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
