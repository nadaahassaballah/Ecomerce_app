using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.identity.entity
{
    public class APPUser:IdentityUser
    {

        public string DisplayName { get; set; } = default;
        public Address?Address { get; set; }
    }
}
