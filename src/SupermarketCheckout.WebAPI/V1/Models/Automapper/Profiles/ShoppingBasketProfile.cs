﻿namespace SupermarketCheckout.WebAPI.V1.Models.Automapper.Profiles
{
    using AutoMapper;
    using SupermarketCheckout.BusinessLogic.Models;

    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per profile.
    /// </summary>
    public class ShoppingBasketProfile : Profile
    {
        /// <inheritdoc />
        public ShoppingBasketProfile()
        {
            CreateMap<ShoppingBasket, ShoppingBasketDto>().ReverseMap();
        }

        /// <inheritdoc />
        public override string ProfileName => GetType().Name;
    }
}
