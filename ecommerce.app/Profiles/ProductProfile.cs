using AutoMapper;
using ecomerce_domain.entities.product;
using ecommerce.app.DTOS.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ecommerce.app.Profiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile() {
        CreateMap<Product,ProductsDTO>().ForMember(
        dest => dest.productbrand,
        opt => opt.MapFrom(src => src.productbrand.Name)).ForMember(d=>d.producttype,p=>p.MapFrom(s=>s.ProductType.Name)).ForMember(d=>d.pictureurl,o=>o.MapFrom<picturalurlresolver>());


            CreateMap<Productbrand, BrandDTO>();
            CreateMap<ProductType, TypeDTO>();


        }
    }
}
