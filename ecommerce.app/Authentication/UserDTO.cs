using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.Authentication
{
    public class UserDTO
    {
        public string Email { get; set; } = default;
        public string Token { get; set; } = default;
        public string DisplayName { get; set; } = default;

    }
}
