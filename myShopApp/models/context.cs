using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShopApp.models
{
    public class context: DbContext
    {

        public DbSet<catgory> catgory { set; get; }
        public DbSet<product> product { set; get; }
        public DbSet<factorDetail> factorDetails { set; get; }
        public DbSet<factors> factors { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object useSqlServer = optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = localhost; Integrated Security = true");
        }
        

    }
}
