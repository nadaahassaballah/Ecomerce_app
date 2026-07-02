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

        public Expression<Func<Tentity, object>> orderby { get; private set; }
        protected void AddOrderBy(Expression<Func<Tentity, object>> orderbyExpression) {
        orderby=orderbyExpression;
        
        }

        public Expression<Func<Tentity, object>> orderbydesc {  get; private set; }

        public int take {  get; private set; }

        public int Skip {  get; private set; }

        public bool ispaginated { get; private set; }
        protected void applypiganiation(int pagesize,int pageindex) { ispaginated = true;
            take = pageindex;

            Skip=(pageindex-1)*pagesize;
                }

        protected void AddOrderByDesc(Expression<Func<Tentity, object>> orderbydescExpression)
        {
            orderbydesc = orderbydescExpression;

        }

        protected basespesifacation(Expression<Func<Tentity, bool>> Criteria)
        {
            criteria = Criteria;
        }

        protected void AddInclude(Expression<Func<Tentity, object>> include)
       => includeExpression.Add(include);


    }
}
