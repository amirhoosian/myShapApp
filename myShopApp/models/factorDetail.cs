using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShopApp.models
{
    public class factorDetail
    {
        public int id { get; set; }
        public int factorid { get; set; }
        public int productid { get; set; }
        public int numbers { get; set; }
        public decimal itemPrice { get; set; }
        public decimal fianlPrice { get; set; }
        public String sellerName { get; set; }
        public List<product> products { get; set; }
        public factors factor { get; set; }
    }
}
