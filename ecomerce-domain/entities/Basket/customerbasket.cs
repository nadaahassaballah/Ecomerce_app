using ecomerce_domain.entities.Bascket;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.entities.Basket
{
    public class customerbasket
    {
        public String id { get; set; } = default;
        public ICollection<Basketitem> items { get; set; } = [];
    }
}
