using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data.Entities;
using Microsoft.Extensions.Logging;
using xSystem.Core.Data;

namespace Catalog.API.Services
{
    public class ProductService: IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IEntityRepositoryWithGenericId<Product, Guid> _repository;

        public ProductService(ILogger<ProductService> logger, IEntityRepositoryWithGenericId<Product, Guid> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _repository.InsertAsync(product);
        }
    }
}
