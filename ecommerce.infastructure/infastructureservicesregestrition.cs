using ecomerce_domain.contract;
using ecommerce.app.contracts;
using ecommerce.infastructure.data;
using ecommerce.infastructure.identity.data;
using ecommerce.infastructure.identity.entity;
using ecommerce.infastructure.identity.Service;
using ecommerce.infastructure.Repositories;
using ecommerce.infastructure.seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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
            services.AddKeyedScoped<IDataSeeder, IdentityDataSeader>("Identity");

            services.AddScoped<iunitofworks, unitofwork>();

            services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);
            }

                );
            services.AddScoped<IBasketReposatery,BasketRposatory >();
            services.AddSingleton<ICashRepository,CasheRepo>();
            services.AddDbContext<StoreIdentityDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentityCore<APPUser>()
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<StoreIdentityDBContext>();
            services.AddScoped<IIDentityService, IdentityService>();
            services.AddScoped<ITokenService, TokenService>();
            services.Configure<JWTSettings>(configuration.GetSection("JWT"));

            var jwtsetting = configuration.GetSection("JWT").Get<JWTSettings>()
            ?? throw new InvalidOperationException("JWT Setting is not configured");

       
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer=jwtsetting.Issuer,
                    ValidAudience=jwtsetting.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime=true,
                    RequireSignedTokens=true
                    ,ClockSkew=TimeSpan.Zero,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsetting.SecretKey)),

                };
            });


            return services; 
        }
    }
}
