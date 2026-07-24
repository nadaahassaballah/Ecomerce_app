using ecomerce_domain.contract;
using ecommerce.infastructure.identity.data;
using ecommerce.infastructure.identity.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // Ensure CancellationToken is available

namespace ecommerce.infastructure.seeding
{
    public class IdentityDataSeader : IDataSeeder
    {
        private readonly StoreIdentityDBContext dBContext;
        private readonly UserManager<APPUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<IdentityDataSeader> logger;

        public IdentityDataSeader(StoreIdentityDBContext dBContext, UserManager<APPUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<IdentityDataSeader> logger)
        {
            this.dBContext = dBContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        public async Task seedasync(CancellationToken ct = default)
        {
            try
            {
                var pendingMigrations = await dBContext.Database.GetPendingMigrationsAsync(ct);

                if (pendingMigrations.Any())
                    await dBContext.Database.MigrateAsync(ct);

                if (!await roleManager.Roles.AnyAsync(ct))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }

                if (!await userManager.Users.AnyAsync(ct))
                {
                    var admin = new APPUser
                    {
                        DisplayName = "Mohammed Ahmed",
                        Email = "Mohammed@gmail.com",
                        UserName = "Mohamed",
                        PhoneNumber = "01225770196"
                    };

                    var createResult = await userManager.CreateAsync(admin, "P@ssw0rd");

                    if (createResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }
                    else
                    {
                        logger.LogWarning(
                            "Could Not Seed Default Admin User: {Errors}",
                            string.Join("; ", createResult.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database");
                throw;
            }
        }
    }
}
