using ecomerce_domain.common;
using ecomerce_domain.contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.spessification
{
    public class SpessificationEvaloute
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
    IQueryable<TEntity> inputQuery,
    ispesification<TEntity, TKey> spec)
    where TEntity : baseentity<TKey>
        {
            var query = inputQuery;
            if (spec.criteria != null) {
                query = query.Where(spec.criteria
                    );
            }

            if (spec.includeExpression.Any())
            {
                query = spec.includeExpression.Aggregate(
                    query,
                    (current, include) => current.Include(include));
            }
            if (spec.orderby!=null) query=query.OrderBy(spec.orderby);
            else if (spec.orderbydesc != null) query = query.OrderByDescending(spec.orderbydesc);
            if (spec.ispaginated)
            {
                query = query.Skip(spec.Skip).Take(spec.take);
            }
            return query;
        }
    }
}
