using AutoMapper;
using ecomerce_domain.entities.Bascket;
using ecomerce_domain.entities.Basket;
using ecommerce.app.DTOS.basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<customerbasket, BasketDTO>().ReverseMap();
            CreateMap<Basketitem, BasketDTO>().ReverseMap();
        }
    }
}
