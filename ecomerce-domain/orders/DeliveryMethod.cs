using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.orders
{
    public class DeliveryMethod : baseentity<int>
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public string ShortNameIf { get; set; }
        public decimal Cost { get; set; } // Added to fix CS1061
    }
}
