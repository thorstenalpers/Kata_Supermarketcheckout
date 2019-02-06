namespace CoreAPI1.API.V2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using AutoMapper;
    using System.Linq;
    using SupermarketCheckout.API.V2.Models;
    using SupermarketCheckout.BusinessLogic.Services;

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
        readonly IMapper _mapper;
        readonly ISupermarketCheckoutService _supermarketCheckout;
        readonly ISupermarketBasketFactory _supermarketBasketFactory;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketCheckout"></param>
        /// <param name="supermarketBasketFactory"></param>
        /// <param name="mapper"></param>
        public SupermarketCheckoutController(ISupermarketCheckoutService supermarketCheckout, ISupermarketBasketFactory supermarketBasketFactory, IMapper mapper)
        {
            _mapper = mapper;
            _supermarketCheckout = supermarketCheckout;
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
        public ActionResult<Bill> CreateBill([FromBody] ShoppingCart cart)
        {
            if (cart == null || cart.Items == null || !cart.Items.Any())
                return StatusCode(StatusCodes.Status400BadRequest);

            var basket = _supermarketBasketFactory.Create(Mapper.Map<IList<SupermarketCheckout.BusinessLogic.Models.EArticle>>(cart.Items));
            var bill = _supermarketCheckout.CreateBill(basket);

            if (bill != null)
                return Ok(_mapper.Map<Bill>(bill));

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
