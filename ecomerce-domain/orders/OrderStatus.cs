using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.orders
{
    public enum OrderStatus
    {
        Pending = 0,
        PaymentReceived = 1,
        PaymentFailed = 2

    }
}
