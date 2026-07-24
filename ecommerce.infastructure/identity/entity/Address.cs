using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.identity.entity
{
    public class Address
    {
        public int Id { get; set; }
        public string city { get; set; } = default;
        public string street { get; set; } = default;
        public string country { get; set; } = default;
        public string firstname { get; set; } = default;
        public string lastname { get; set; } = default;
        public APPUser user { get; set; } = default;
        public string userid { get; set; } = default;
    }
}
