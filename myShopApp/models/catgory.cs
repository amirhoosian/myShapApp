using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShopApp.models
{
    public class catgory
    {
        public int id { get; set; }
        public String title { get; set; }

        public List<product> products { get; set; }

    }
}
