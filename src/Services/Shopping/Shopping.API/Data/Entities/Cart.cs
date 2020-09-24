using System;
using System.Collections.Generic;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data.Entities
{
    public class Cart: BaseEntityWithGenericId<Guid>
    {
        private ICollection<CartItem> _cartItems;
        public Guid ShopperId { get; set; }
        public string ShopperName { get; set; }
        public long CartNo { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the collection of order items
        /// </summary>
        public virtual ICollection<CartItem> CartItems
        {
            get { return _cartItems ?? (_cartItems = new List<CartItem>()); }
            protected set { _cartItems = value; }
        }
    }
}
