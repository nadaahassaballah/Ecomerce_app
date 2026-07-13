using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.contracts
{
    public interface ICasheService
    {
        Task<string?> GetAsync(string key, CancellationToken ct = default);
        Task SetAsync(string key,object cahse,TimeSpan TimeToLive, CancellationToken ct = default);
    }
}
