using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.DTOS.products
{
    public class ProductsDTO
    {
        public int id {  get; set; }
        public string name { get; set; } = default;
        public string description { get; set; } = default;
        public decimal price { get; set; } = default;
        public string pictureurl { get; set; } = default;
        public string productbrand { get; set; } = default;
        public string producttype{ get; set; } = default;


    }
}
