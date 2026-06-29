using ecomerce_domain.entities.product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.data.configuration
{
    internal class productconfiguration:IEntityTypeConfiguration<Product>
    {
public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.productbrand).WithMany().HasForeignKey(x => x.brandid);
            builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x => x.typeid);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Picutureurl).HasMaxLength(200);



        }
    }
}
