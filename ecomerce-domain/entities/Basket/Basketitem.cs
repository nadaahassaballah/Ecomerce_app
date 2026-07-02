using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.entities.Bascket
{
    public class Basketitem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picurl { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }


    }
}
