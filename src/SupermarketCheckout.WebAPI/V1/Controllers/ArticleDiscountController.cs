namespace SupermarketCheckout.WebAPI.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SupermarketCheckout.WebAPI.V1.Models;
    using SupermarketCheckout.BusinessLogic.Services;
    using System.Threading.Tasks;
    using AutoMapper;
    using System.Collections.Generic;

    /// <summary>
    /// Crates a checkout for a supermarket
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class ArticleDiscountController : Controller
    {
        readonly ISupermarketStoreService _supermarketStoreService;
        readonly IMapper _mapper;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketStoreService"></param>
        /// <param name="mapper"></param>
        public ArticleDiscountController(ISupermarketStoreService supermarketStoreService, IMapper mapper)
        {
            _supermarketStoreService = supermarketStoreService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all discounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<ArticleDiscount>>> Index()
        {
            var list = await _supermarketStoreService.GetAllDiscounts().ConfigureAwait(true);
            return Ok(_mapper.Map<IList<ArticleDiscount>>(list));
        }     
    }
}
