﻿using Mapster;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Product;

namespace MercuryProject.API.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductResult, ProductResponse>().Map(dest => dest.Id, src => src.Product.Id.Value)
                .Map(dest => dest, src => src.Product);
        }
    }
}
