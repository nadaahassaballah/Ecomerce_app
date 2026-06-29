using AutoMapper;
using AutoMapper.Execution;
using ecomerce_domain.entities.product;
using ecommerce.app.DTOS.products;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.Profiles
{
    internal class picturalurlresolver(IOptions<urlsetting>options):IValueResolver<Product,ProductsDTO,string?>
    {
        
        private readonly urlsetting _urlsetting=options.Value;
        public string? Resolve(Product source, ProductsDTO destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Picutureurl)) return null;
            var baseurl = _urlsetting.baseurl.TrimEnd('/');
            var path =source.Picutureurl.TrimEnd('/');
            return $"{baseurl}/Files/{path}";
        }
    }
    public class urlsetting
    {
        public string baseurl { get; set; }

    }
}
