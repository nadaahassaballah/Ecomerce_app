using ecomerce_domain.common;
using ecomerce_domain.contract;
using ecommerce.infastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.Repositories
{
    public class unitofwork(storeDbcontext dbcontext) : iunitofworks
    {
        private readonly Dictionary<string,object> _directory = [];
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : baseentity<Tkey>
        {
            var typename = typeof(TEntity).Name;
            if (_directory.TryGetValue(typename, out var directory)) 
                return (IGenericRepository<TEntity,Tkey>)directory;
            var repo = new genericrepository<TEntity, Tkey>(dbcontext);
            _directory[typename] = repo;
            return repo;

            
             
                
                }

        public Task<int> savechangesasync(CancellationToken ct = default)
       =>dbcontext.SaveChangesAsync(ct);
    }
}
