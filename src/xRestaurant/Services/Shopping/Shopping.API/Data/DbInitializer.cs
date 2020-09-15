using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShoppingDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
