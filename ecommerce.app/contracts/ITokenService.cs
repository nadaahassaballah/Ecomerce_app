using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface ITokenService
    {
        string creatToken(string userid,string email,string username,IEnumerable<string>roles);
    }
}
