using ecommerce.infastructure.identity.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.identity.data
{
    public class StoreIdentityDBContext(DbContextOptions<StoreIdentityDBContext>Options) : IdentityDbContext<APPUser>(Options)
    {
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region DbSets

            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<APPUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            #endregion
            builder.Entity<APPUser>().HasOne(a=>a.Address).WithOne(u=>u.user).HasForeignKey<Address>(a=>a.userid).OnDelete(DeleteBehavior.Cascade);
        }
    
   
    }
}
