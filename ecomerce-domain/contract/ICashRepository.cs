using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface ICashRepository
    {
        Task<string?>GetAsync(string key,CancellationToken ct=default);
        Task SetAsync(string key,string cashValue,TimeSpan TimetoLive,CancellationToken ct=default);
    }
}
