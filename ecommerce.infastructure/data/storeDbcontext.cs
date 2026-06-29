using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce_domain.entities.product;
namespace ecommerce.infastructure.data;

public class storeDbcontext(DbContextOptions<storeDbcontext>options):DbContext(options)
{
    #region dbset
     
    public DbSet<Product> products { get; set; }
     public DbSet<ProductType> productTypes { get; set; }
    public DbSet<Productbrand> productbrands { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(storeDbcontext).Assembly);
    }

}
