using System;
using System.Collections.Generic;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data.Entities
{
    public class Cart: BaseEntity
    {
        public Guid ShopperId { get; set; }
        public string ShopperName { get; set; }
        public long CartNo { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
