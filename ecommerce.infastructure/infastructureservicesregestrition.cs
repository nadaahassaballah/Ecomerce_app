using ecomerce_domain.contract;
using ecommerce.infastructure.data;
using ecommerce.infastructure.Repositories;
using ecommerce.infastructure.seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ecommerce.infastructure
{
    public static class infastructureservicesregestrition
    {
        public static IServiceCollection addinfastrucrureservice(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<storeDbcontext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefultConnection"));
            });


            services.AddKeyedScoped<IDataSeeder, catalogdataseeding>("Catalog");
            services.AddScoped<iunitofworks, unitofwork>();
            return services;
        }
    }
}
