using ecomerce_domain.contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.Repositories
{
    public class CasheRepo : ICashRepository
    {private readonly IDatabase _database;
        public CasheRepo(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<string?> GetAsync(string key, CancellationToken ct = default)
        {
            var valur = await _database.StringGetAsync(key);
            return valur.IsNullOrEmpty ? null : valur.ToString();
        }

        public Task SetAsync(string key, string cashValue, TimeSpan TimetoLive, CancellationToken ct = default)
       =>_database.StringSetAsync(key,cashValue,TimetoLive);
    }
}
