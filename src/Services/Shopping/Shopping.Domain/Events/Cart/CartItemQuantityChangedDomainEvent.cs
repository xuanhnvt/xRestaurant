using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Events;

namespace Shopping.Domain.Events.Cart
{
    public class CartItemQuantityChangedDomainEvent: BaseEvent
    {
        public Guid CartItemId { get; }
        public int Quantity { get; }
        public CartItemQuantityChangedDomainEvent(Guid cartId, Guid cartItemId, int quantity)
        {
            Id = cartId;
            CartItemId = cartItemId;
            Quantity = quantity;
        }
    }
}
