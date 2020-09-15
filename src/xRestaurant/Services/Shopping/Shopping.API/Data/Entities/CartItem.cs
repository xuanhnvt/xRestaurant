using System;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data.Entities
{
    public class CartItem: BaseEntity
    {
        public Guid CartId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public Cart Cart { get; set; }
    }
}
