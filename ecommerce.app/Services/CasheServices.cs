using ecomerce_domain.contract;
using ecommerce.app.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ecommerce.app.Services
{
    public class CasheServices : ICasheService
    {private readonly ICashRepository _cashRepository;
        public CasheServices(ICashRepository cashRepository) { 
        _cashRepository = cashRepository;
        }
        public Task<string?> GetAsync(string key, CancellationToken ct = default)
        =>_cashRepository.GetAsync(key, ct);

   

        Task ICasheService.SetAsync(string key, object cahse, TimeSpan TimeToLive, CancellationToken ct)
        {
            var json = JsonSerializer.Serialize(key, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return _cashRepository.SetAsync(key, json, TimeToLive, ct);
        }
    }
}
