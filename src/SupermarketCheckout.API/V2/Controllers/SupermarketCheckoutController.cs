namespace CoreAPI1.API.V2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using SupermarketCheckout.API.V2.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using SupermarketCheckout.Common.Models;

    /// <summary>
    /// Crates a checkout for a supermarket
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]     //required for default versioning
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class SupermarketCheckoutController : Controller
    {
        readonly ISupermarketCheckoutService _supermarketCheckoutService;
        readonly IShoppingCartFactory _supermarketCartFactory;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketCheckoutService"></param>
        /// <param name="supermarketCartFactory"></param>
        public SupermarketCheckoutController(ISupermarketCheckoutService supermarketCheckoutService, IShoppingCartFactory supermarketCartFactory)
        {
            _supermarketCheckoutService = supermarketCheckoutService;
            _supermarketCartFactory = supermarketCartFactory;
        }

        /// <summary>
        /// Creates a bill by a given shopping cart
        /// </summary>
        /// <param name="basket">A shopping basket</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Bill> CreateBill([FromBody] ShoppingBasket basket)
        {
            if (basket == null || basket.Articles == null || !basket.Articles.Any())
                return StatusCode(StatusCodes.Status400BadRequest);

            var cart = _supermarketCartFactory.Create(basket.Articles);
            var bill = _supermarketCheckoutService.CreateBill(cart);

            if (bill != null)
                return Ok(bill);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
