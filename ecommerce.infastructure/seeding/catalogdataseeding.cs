using ecommerce.infastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


using ecomerce_domain.contract;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ecomerce_domain.entities.product;
using ecomerce_domain.orders;

namespace ecommerce.infastructure.seeding
{
    public class catalogdataseeding(storeDbcontext dbcontext, ILogger<catalogdataseeding> looger) : IDataSeeder
    {
        public async Task seedasync(CancellationToken ct = default)
        {
            try
            {
                var pendingmigration = await dbcontext.Database.GetPendingMigrationsAsync(ct);
                if (pendingmigration.Any()) await dbcontext.Database.MigrateAsync(ct);



                var seedroot = Path.Combine(AppContext.BaseDirectory, "dataseed");
                await seedifemptyasync<Productbrand>(seedroot, "brands.json", ct);

                await seedifemptyasync<ProductType>(seedroot, "types.json", ct);

                await seedifemptyasync<Product>(seedroot, "products.json", ct);

                await seedifemptyasync<DeliveryMethod>(seedroot, "delivery.json", ct);

                await dbcontext.SaveChangesAsync(ct);




            }


            catch(Exception ex) {

                looger.LogError(ex, "catalog data seeding failed");
                throw;

            }

        }
        private async Task seedifemptyasync<t>(string root, string filename, CancellationToken ct = default) where t : class
        {
            if (await dbcontext.Set<t>().AnyAsync(ct)) return;
            var path = Path.Combine(root, filename);
            if (!File.Exists(path))
            {
                looger.LogWarning("File not found: {Path}", path);
                return;
            }
            await using var stream = File.OpenRead(path);
            var iteams = await JsonSerializer.DeserializeAsync<List<t>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, ct);
            if (iteams ?.Count > 0)
            {
                await dbcontext.Set<t>().AddRangeAsync(iteams,ct);
            }
        }
    }
}
