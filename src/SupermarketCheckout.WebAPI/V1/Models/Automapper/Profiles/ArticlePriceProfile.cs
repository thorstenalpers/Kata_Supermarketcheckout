namespace SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles
{
    using AutoMapper;
    using SupermarketCheckout.BusinessLogic.Models;

    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per profile.
    /// </summary>
    public class ArticlePriceProfile : Profile
    {
        /// <inheritdoc />
        public ArticlePriceProfile()
        {
            CreateMap<SupermarketCheckout.WebAPI.V1.Models.ArticlePrice, ArticlePriceDto>().ReverseMap();

            CreateMap<ArticlePriceDto, SupermarketCheckout.DataAccess.Models.ArticlePrice>()
                .ForMember(dst => dst.ArticleId, config => config.Ignore());

            CreateMap<DataAccess.Models.ArticlePrice, ArticlePriceDto>();

        }

        /// <inheritdoc />
        public override string ProfileName => GetType().Name;
    }
}
