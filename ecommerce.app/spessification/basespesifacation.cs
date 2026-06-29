using ecomerce_domain.common;
using ecomerce_domain.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.spessification
{
    public class basespesifacation<Tentity, TKey> : ispesification<Tentity, TKey> where Tentity : baseentity<TKey>
    {
        public ICollection<Expression<Func<Tentity, object>>> includeExpression { get; } = [];

        public Expression<Func<Tentity, bool>> criteria {get;
            private  set;}
        protected basespesifacation(Expression<Func<Tentity, bool>> Criteria)
        {
            criteria = Criteria;
        }

        protected void AddInclude(Expression<Func<Tentity, object>> include)
       => includeExpression.Add(include);
    }
}
