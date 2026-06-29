using ecomerce_domain.common;
using ecomerce_domain.contract;
using ecommerce.app.spessification;
using ecommerce.infastructure.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infastructure.Repositories
{
    public class genericrepository<TEntity, TKey>(storeDbcontext dbcontext) : IGenericRepository<TEntity, TKey> where TEntity : baseentity<TKey>
    {
        public void add(TEntity entity)=>dbcontext.Set<TEntity>().Add(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
       => await dbcontext.Set<TEntity>().AsNoTracking().ToListAsync(ct);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(ispesification<TEntity, TKey> Spec, CancellationToken ct = default)
        {
           var query = SpessificationEvaloute.CreateQuery(dbcontext.Set<TEntity>(), Spec);

            return await query.ToListAsync(ct);
        }

        public  async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default)
             => await dbcontext.Set<TEntity>().FindAsync([id!], ct).AsTask();

        public async Task<TEntity?> GetByIdAsync(ispesification<TEntity, TKey> Spec, CancellationToken ct = default)
        {
            var query = SpessificationEvaloute.CreateQuery(dbcontext.Set<TEntity>(), Spec);

            return await query.FirstOrDefaultAsync();
        }

        public void remove(TEntity entity) => dbcontext.Set<TEntity>().Remove(entity);

        public void update(TEntity entity) => dbcontext.Set<TEntity>().Update(entity);
    }
}
