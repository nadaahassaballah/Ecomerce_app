using ecomerce_domain.entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface IBasketReposatery
    {
        Task<customerbasket?> GetBasketAsync(string bascketid, CancellationToken ct);
        Task<customerbasket?> CreatOrUpdateAsync(customerbasket basket, TimeSpan? TimeToLive = null, CancellationToken ct=default);
            Task<bool>DeleteBasket(string basketid, CancellationToken ct);
    }
}
