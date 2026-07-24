using ecomerce_domain.contract;

namespace ecommerce.api.Extensions
{
    public static class webappextensions
    {
        public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            var identity = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Identity");

            await seeder.seedasync();
            await identity.seedasync();
            return app;
                
                
                }
    }
}
