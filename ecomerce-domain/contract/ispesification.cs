using ecomerce_domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce_domain.contract
{
    public interface ispesification<Tentity,TKey>where Tentity:baseentity<TKey>
    {


        ICollection<Expression<Func<Tentity, object>>> includeExpression {  get; }

        Expression<Func<Tentity, bool>> criteria { get; }


        Expression<Func<Tentity, object>> orderby { get; }
        Expression<Func<Tentity, object>> orderbydesc { get; }
        int take {  get; }
        int Skip { get; }
        bool ispaginated { get; }

    }
}
