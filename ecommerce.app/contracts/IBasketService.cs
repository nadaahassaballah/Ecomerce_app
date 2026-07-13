using ecommerce.app.common;
using ecommerce.app.DTOS.basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface IBasketService
    {
        Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default);
        Task<Result<BasketDTO>>CreateOrUpdateBasketAsync(BasketDTO basket,CancellationToken ct = default);
        Task<Result<bool>>DeleteBasketAsync(String id , CancellationToken ct = default);
    }
}
