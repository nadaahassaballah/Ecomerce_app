using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.entities.product
{
    public class Product:baseentity<int>
    {
        public string Name { get; set; } = default;
        public string Description { get; set; } = default;
        public string Picutureurl { get; set; } = default;
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; } = default;
        public int typeid { get; set; }
        public Productbrand productbrand { get; set; } = default;
        public int brandid { get; set; }

    }
}
