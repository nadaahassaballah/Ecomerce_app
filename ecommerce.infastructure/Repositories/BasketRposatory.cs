using ecomerce_domain.contract;
using ecomerce_domain.entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace ecommerce.infastructure.Repositories
{
    public class BasketRposatory : IBasketReposatery
    {private readonly IDatabase _database;
        public BasketRposatory(IConnectionMultiplexer connection)
        {
            _database=connection.GetDatabase();
        }
        public async Task<customerbasket?> CreatOrUpdateAsync(customerbasket basket, TimeSpan? TimeToLive = null, CancellationToken ct = default)
        {
var json=JsonSerializer.Serialize(basket);
            var sucess=await _database.StringSetAsync(basket.id,json,TimeToLive??TimeSpan.FromDays(30));
            
            return sucess?basket:null;
                }

        public async Task<bool> DeleteBasket(string basketid, CancellationToken ct)
        => await _database.KeyDeleteAsync(basketid);

        public async Task<customerbasket?> GetBasketAsync(string bascketid, CancellationToken ct)
        {
            var basket = await _database.StringGetAsync(bascketid);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<customerbasket>(basket!);
        }
    }
}
