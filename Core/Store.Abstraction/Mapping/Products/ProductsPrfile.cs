using AutoMapper;
using Store.Domain.Entities.Products;
using Store.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Products
{
    public class ProductsPrfile:Profile
    {
        public ProductsPrfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name));
            CreateMap<ProductBrand, BrandTypeReponse>();
            CreateMap<ProductType, BrandTypeReponse>();
        }
    }
}
