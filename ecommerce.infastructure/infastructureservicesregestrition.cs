using ecomerce_domain.contract;
using ecommerce.infastructure.data;
using ecommerce.infastructure.Repositories;
using ecommerce.infastructure.seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Reflection.Metadata.Ecma335;

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

            services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);
            }

                );
            services.AddScoped<IBasketReposatery,BasketRposatory >();
            services.AddSingleton<ICashRepository,CasheRepo>();
            return services;
        }
    }
}
