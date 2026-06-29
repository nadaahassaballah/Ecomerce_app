using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.entities.product
{
    public class ProductType:baseentity<int>
    {
        public string Name { get; set; } = default;
    }
}
