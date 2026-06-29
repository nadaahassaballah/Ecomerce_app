using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface iunitofworks
    {
        Task<int> savechangesasync(CancellationToken ct = default);
        IGenericRepository<TEntity,Tkey>GetRepository<TEntity,Tkey>()where TEntity:baseentity<Tkey>;
    }
}
