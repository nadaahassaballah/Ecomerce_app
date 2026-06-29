using ecommerce.app.contracts;
using ecommerce.app.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app
{
    public static class APPservicesregestration
    {
         
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(APPservicesregestration).Assembly);
            services.AddScoped<IProductService, ProductServices>();
            return services;
        }
    }

}
