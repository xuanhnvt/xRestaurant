using System;
using System.Collections.Generic;
using System.Text;
using Shopping.Domain.Aggregates.Cart;

namespace Shopping.Domain.Events.Cart
{
    public class CartCreatedDomainEvent: BaseEvent
    {
        public Guid ShopperId { get; }
        public string ShopperName { get; }
        public List<CartItem> CartItems { get; }

        public CartCreatedDomainEvent(Guid cartId, Guid shopperId, string shopperName, List<CartItem> cartItems)
        {
            Id = cartId;
            ShopperId = shopperId;
            ShopperName = shopperName;
            CartItems = cartItems ?? throw new ArgumentNullException();
        }
    }
}
