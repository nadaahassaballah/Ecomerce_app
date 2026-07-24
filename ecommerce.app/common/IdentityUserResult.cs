using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.common
{
    public class IdentityUserResult
    {
        public IdentityUserResult(string id, string username, string email, string displayName)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            DisplayName = displayName;
        }

        public string id { get; set; } = default;
        public string username { get; set; }
        public string email { get; set; }
        public string DisplayName { get; set; } = default;
    }
}
