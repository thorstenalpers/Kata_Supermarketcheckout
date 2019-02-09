namespace SupermarketCheckout.WebAPI.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using SupermarketCheckout.WebAPI.V1.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using System.Threading.Tasks;
    using AutoMapper;
    using System.Linq;
    using SupermarketCheckout.BusinessLogic.Models;

    /// <summary>
    /// Crates a checkout for a supermarket
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SupermarketCheckoutController : Controller
    {
        readonly ISupermarketCheckoutService _supermarketCheckoutService;
        readonly IMapper _mapper;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketCheckoutService"></param>
        /// <param name="mapper"></param>
        public SupermarketCheckoutController(ISupermarketCheckoutService supermarketCheckoutService, IMapper mapper)
        {
            _supermarketCheckoutService = supermarketCheckoutService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a bill by a given shopping cart
        /// </summary>
        /// <example>
        /// {
        /// "articles": [
        ///   {
        ///     "article": {
        ///      "id": 2,
        ///      "name": "Banana"
        ///  },
        ///   "numberOfArticles": 10,
        ///   "articleDiscount": {
        ///    "id": 1,
        ///    "article": {
        ///      "id": 2,
        ///      "name": "Banana"
        ///  },
        ///    "numberOfArticles": 3,
        ///    "newPrice": 130
        ///   },
        ///   "articlePrice": {
        ///     "id": 1,
        ///     "article": {
        ///        "id": 2,
        ///        "name": "Banana"
        ///  },
        ///     "unitPrice": 50
        ///   }
        ///  }
        ///  ]
        ///    }
        /// </example>
        /// <param name="basket">A shopping basket</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Bill>> Index([FromBody] ShoppingBasket basket)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if (basket == null || basket.Articles == null || !basket.Articles.Any())
                return StatusCode(StatusCodes.Status400BadRequest);

            //var cart = _shoppingCartFactory.Create(basket.Articles);
            var billDto = await _supermarketCheckoutService.CreateBill(_mapper.Map<ShoppingBasketDto>(basket)).ConfigureAwait(true);

            var bill = _mapper.Map<Bill>(billDto);
            if (bill != null)
                return Ok(bill);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
