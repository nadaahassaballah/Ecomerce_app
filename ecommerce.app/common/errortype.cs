using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ecommerce.app.common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum errortype
    {

        failure=0,validation=1,notfound=2,conflict=3,unauthorized=4,forbidden=5,invalidcredtials=6
    }
}
