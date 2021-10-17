using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShopApp.models
{
    public class factors
    {
        public int id { get; set; }
        public String buyerName { get; set; }
        public int status { get; set; }
        public decimal funalPrice { get; set; }
        public factorDetail factordetail { get; set; }
    }
}
