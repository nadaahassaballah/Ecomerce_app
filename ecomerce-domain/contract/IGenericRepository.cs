using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : baseentity<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(ispesification<TEntity,TKey>Spec,CancellationToken ct = default);

        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task <TEntity?>GetByIdAsync( TKey id,CancellationToken ct = default);

        Task<TEntity?> GetByIdAsync(ispesification<TEntity, TKey> Spec, CancellationToken ct = default);

        void add(TEntity entity);
        void remove(TEntity entity);
        void update(TEntity entity);
    }
}
