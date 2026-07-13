using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.DTOS.basket
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string picurl { get; set; }
        [Range(1,double.MaxValue)]
        public decimal price { get; set; }
        [Range(1, 90)]

        public int quantity { get; set; }
    }
}
