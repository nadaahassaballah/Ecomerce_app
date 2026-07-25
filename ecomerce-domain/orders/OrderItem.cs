using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.orders
{
    public class OrderItem:baseentity<int>
    {
        public ProductItemOrder Product { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
