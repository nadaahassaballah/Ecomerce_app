using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface IDataSeeder
    {
        Task seedasync(CancellationToken ct= default);
    }
}
