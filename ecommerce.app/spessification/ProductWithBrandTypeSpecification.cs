using ecomerce_domain.entities.product;
using ecommerce.app.common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.spessification
{
    public class ProductWithBrandTypeSpecification : basespesifacation<Product, int>
    {
        public ProductWithBrandTypeSpecification(Productquerryprams productquerryprams) : base


            (p => (!productquerryprams.BrandId.HasValue || p.brandid == productquerryprams.BrandId.Value) && (!productquerryprams.TypeId.HasValue || p.typeid == productquerryprams.TypeId.Value) && (string.IsNullOrEmpty(productquerryprams.serarchvalue) || p.Name.ToLower().Contains(productquerryprams.serarchvalue)))
        {
            AddInclude(x => x.productbrand);
            AddInclude(x => x.ProductType);
        }
        public ProductWithBrandTypeSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.productbrand);
            AddInclude(x => x.ProductType);
        }
    }
}
