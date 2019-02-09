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
    public class ArticleController : Controller
    {
        readonly ISupermarketStoreService _supermarketStoreService;
        readonly IMapper _mapper;

        /// <summary>
        /// wire up dependencies
        /// </summary>
        /// <param name="supermarketStoreService"></param>
        /// <param name="mapper"></param>
        public ArticleController(ISupermarketStoreService supermarketStoreService, IMapper mapper)
        {
            _supermarketStoreService = supermarketStoreService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<Article>>> Index()
        {
            var list = await _supermarketStoreService.GetAllArticles().ConfigureAwait(true);
            return Ok(_mapper.Map<IList<Article>>(list));
        }       
    }
}
