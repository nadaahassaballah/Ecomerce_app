using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.app.common
{
    public class Productquerryprams
    {
        public int ?BrandId { get; set; }
        public int? TypeId { get; set; }
        public string ?serarchvalue{ get; set; }  
        public ProductSortingOption? sortingoption{ get; set; }
        public int pageindex { get; set; } = 1;
        private const int Defaultpagesize = 5;
        private const int maxpagesize = 10;
        private int pagesize = Defaultpagesize;
        public int Pagesize
        {
            get => pagesize;
            set => pagesize = value > maxpagesize
                ? maxpagesize
                : value < 1
                    ? Defaultpagesize
                    : value;
        }

    }
}
