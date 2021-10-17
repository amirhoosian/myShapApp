using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShopApp.models
{
    public class product
    {
        public int id { get; set; }
        public String sellerName { get; set; }
        public int catid { get; set; }
        public String name { get; set; }
        public decimal price { get; set; }
        public String description { get; set; }

        public String imageUrl { get; set; }

        public catgory catgory { get; set; }
        public List<factorDetail> factordetails { get; set; }

    }
}
