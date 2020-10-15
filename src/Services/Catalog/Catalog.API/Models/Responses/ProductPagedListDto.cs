using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xSystem.Core.Paginations;

namespace Catalog.API.Models.Responses
{
    public class ProductPagedListDto: BasePageableModel<ProductPagedListDto.ProductListItem>
    {
        public class ProductListItem
        {
            public long ProductNo { get; set; }
            public string Sku { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int StockQuantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
