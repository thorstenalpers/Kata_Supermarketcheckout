namespace SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles
{
    using AutoMapper;
    using SupermarketCheckout.BusinessLogic.Models;

    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per profile.
    /// </summary>
    public class ArticleDiscountProfile : Profile
    {
        /// <inheritdoc />
        public ArticleDiscountProfile()
        {
            CreateMap<SupermarketCheckout.WebAPI.V1.Models.ArticleDiscount, ArticleDiscountDto>()
                .ReverseMap();
            CreateMap<ArticleDiscountDto, SupermarketCheckout.DataAccess.Models.ArticleDiscount>()
                .ForMember(dst => dst.ArticleId, config => config.Ignore());

            CreateMap<SupermarketCheckout.DataAccess.Models.ArticleDiscount, ArticleDiscountDto>();

        }

        /// <inheritdoc />
        public override string ProfileName => GetType().Name;
    }
}
