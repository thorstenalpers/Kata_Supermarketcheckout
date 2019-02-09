
namespace SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles
{
    using AutoMapper;
    using SupermarketCheckout.BusinessLogic.Models;

    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per profile.
    /// </summary>
    public class ArticleProfile : Profile
    {
        /// <inheritdoc />
        public ArticleProfile()
        {
            CreateMap<SupermarketCheckout.WebAPI.V1.Models.Article, ArticleDto>().ReverseMap();
            CreateMap<ArticleDto, SupermarketCheckout.DataAccess.Models.Article>().ReverseMap();
        }

        /// <inheritdoc />
        public override string ProfileName => GetType().Name;
    }
}
