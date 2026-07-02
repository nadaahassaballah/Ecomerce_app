using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.common
{
    public class Pagginationresult<Tentity>
    {
        public Pagginationresult(int pageindex, int pagesize, int count, IReadOnlyList<Tentity> data)
        {
            this.pageindex = pageindex;
            this.pagesize = pagesize;
            this.count = count;
            Data = data;
        }

        public int pageindex { get; }
        public int pagesize { get; }
        public int count {  get; }
        public IReadOnlyList<Tentity> Data {  get; }
    }
}
