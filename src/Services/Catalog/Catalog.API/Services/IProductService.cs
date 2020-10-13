using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data.Entities;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(Product product);
    }
}
