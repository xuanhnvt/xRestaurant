using System;

namespace Shopping.API.Data.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid ShopperId { get; set; }
        public long CartNo { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
