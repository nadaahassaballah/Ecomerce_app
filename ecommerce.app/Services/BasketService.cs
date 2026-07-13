using AutoMapper;
using ecomerce_domain.contract;
using ecomerce_domain.entities.Basket;
using ecommerce.app.common;
using ecommerce.app.contracts;
using ecommerce.app.DTOS.basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ecommerce.app.Services
{
    public class BasketService(IBasketReposatery basketReposatery, IMapper mapper) : IBasketService
    {
        public async Task<Result<BasketDTO>> CreateOrUpdateBasketAsync(BasketDTO basket, CancellationToken ct = default)
        {
            var custmoerbasket = mapper.Map<customerbasket>(basket);
            var basketResult = await basketReposatery.CreatOrUpdateAsync(custmoerbasket, ct: ct);
            return basketResult != null
                ? Result<BasketDTO>.OK(mapper.Map<BasketDTO>(basketResult))
                : Result<BasketDTO>.Fail(error.Failure("can not delete or update basket"));
        }

        public async Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var result = await basketReposatery.DeleteBasket(id, ct);

            return result
                ? Result<bool>.OK(true)
                : Result<bool>.Fail(error.Failure("Can Not Delete Basket"));
        }
        public async Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var basket = await basketReposatery.GetBasketAsync(id, ct);

            if (basket == null)
                return Result<BasketDTO>.Fail(error.NotFound("Basket Not Found"));

            return Result<BasketDTO>.OK(mapper.Map<BasketDTO>(basket));
        }
    }
}
