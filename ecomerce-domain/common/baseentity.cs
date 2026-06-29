using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.common
{
    public abstract class baseentity<T>
    {
        public T Id { get; set; } = default;
    }
}
