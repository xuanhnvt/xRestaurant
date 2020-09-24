using System;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data.Entities
{
    public class CartItem: BaseEntity
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
