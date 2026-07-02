using ecomerce_domain.entities.product;
using ecommerce.app.common;
using Microsoft.EntityFrameworkCore.Query;
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


            (p => (!productquerryprams.BrandId.HasValue || p.brandid == productquerryprams.BrandId.Value) &&
            (!productquerryprams.TypeId.HasValue || p.typeid == productquerryprams.TypeId.Value) &&
            (string.IsNullOrEmpty(productquerryprams.serarchvalue) || p.Name.ToLower().Contains(productquerryprams.serarchvalue)))
        {
            AddInclude(x => x.productbrand);
            AddInclude(x => x.ProductType);


            switch (productquerryprams.sortingoption)
            {
                case ProductSortingOption.nameAsc:
                    AddOrderBy(x => x.Name);
                    break;
                case ProductSortingOption.nameDesc:
                    AddOrderBy(x => x.Name);
                    break;
                case ProductSortingOption.PriceAsc:
                    AddOrderBy(x => x.Price);
                    break;
                case ProductSortingOption.PriceDesc:
                    AddOrderBy(x => x.Price);
                    break;
                    default:
                    AddOrderBy (x => x.Id);
                    break;
            }
            applypiganiation(productquerryprams.Pagesize, productquerryprams.pageindex);
        }
        public ProductWithBrandTypeSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.productbrand);
            AddInclude(x => x.ProductType);
        }
    }
}
