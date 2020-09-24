using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xSystem.Core.Data.Entities;

namespace Catalog.API.Data.Entities
{
    public class Product: BaseEntityWithGenericId<Guid>
    {
        public long ProductNo { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
