using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Events;

namespace Shopping.Domain.Events.Cart
{
    public class CartItemQuantityUpdated: IEvent
    {
        public Guid CartItemId { get; }
        public int Quantity { get; }
        public CartItemQuantityUpdated(Guid cartId, Guid cartItemId, int quantity)
        {
            Id = cartId;
            CartItemId = cartItemId;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
