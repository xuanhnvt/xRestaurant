using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using xSystem.Core.Data;
using xSystem.Core.Paginations;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IEntityRepositoryWithGenericId<Product, Guid> _productRepository;

        public ProductService(ILogger<ProductService> logger, IEntityRepositoryWithGenericId<Product, Guid> repository)
        {
            _logger = logger;
            _productRepository = repository;
        }

        public async Task InsertProductAsync(Product product)
        {
            await _productRepository.InsertAsync(product);
        }

        public async Task<IPagedList<Product>> SearchProductsAsync(
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            IList<int> categoryIds = null,
            decimal? priceMin = null,
            decimal? priceMax = null,
            string keywords = null,
            bool searchDescriptions = false,
            bool searchSku = true,
            bool showHidden = false)
        {
            // some databases don't support int.MaxValue
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            var query = from product in _productRepository.Table
                        select product;
            var products = await query.OrderBy(p => p.ProductNo).ToListAsync();
            return new PagedList<Product>(products, pageIndex, pageSize);
        }
    }
}
