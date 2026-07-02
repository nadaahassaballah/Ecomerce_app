using ecomerce_domain.entities.product;
using ecommerce.app.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.spessification
{
    public class productcountspesfication:basespesifacation<Product,int>

    {
        public productcountspesfication(Productquerryprams productquerryprams) : base (p => (!productquerryprams.BrandId.HasValue || p.brandid == productquerryprams.BrandId.Value) &&
            (!productquerryprams.TypeId.HasValue || p.typeid == productquerryprams.TypeId.Value) &&
            (string.IsNullOrEmpty(productquerryprams.serarchvalue) || p.Name.ToLower().Contains(productquerryprams.serarchvalue)))
        
            {
            
        }
    }
}
