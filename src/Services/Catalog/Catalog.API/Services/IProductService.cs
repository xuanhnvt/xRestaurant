using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data.Entities;
using xSystem.Core.Paginations;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task<IPagedList<Product>> SearchProductsAsync(
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            IList<int> categoryIds = null,
            decimal? priceMin = null,
            decimal? priceMax = null,
            string keywords = null,
            bool searchDescriptions = false,
            bool searchSku = true,
            bool showHidden = false);

        Task InsertProductAsync(Product product);
    }
}
