using Catalog.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CatalogDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products
            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{Id=new Guid(),Name="Carson",Description="Alexander",CreatedOnUtc=DateTime.Parse("2005-09-01")},
                new Product{Id=new Guid(),Name="Meredith",Description="Alonso",CreatedOnUtc=DateTime.Parse("2002-09-01")},
                new Product{Id=new Guid(),Name="Arturo",Description="Anand",CreatedOnUtc=DateTime.Parse("2003-09-01")},
                new Product{Id=new Guid(),Name="Gytis",Description="Barzdukas",CreatedOnUtc=DateTime.Parse("2002-09-01")},
                new Product{Id=new Guid(),Name="Yan",Description="Li",CreatedOnUtc=DateTime.Parse("2002-09-01")},
                new Product{Id=new Guid(),Name="Peggy",Description="Justice",CreatedOnUtc=DateTime.Parse("2001-09-01")},
                new Product{Id=new Guid(),Name="Laura",Description="Norman",CreatedOnUtc=DateTime.Parse("2003-09-01")},
                new Product{Id=new Guid(),Name="Nino",Description="Olivetto",CreatedOnUtc=DateTime.Parse("2005-09-01")}
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
