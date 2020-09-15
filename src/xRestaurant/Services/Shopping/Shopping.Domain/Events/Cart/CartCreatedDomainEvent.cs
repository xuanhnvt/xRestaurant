using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Events.Cart
{
    public class CartCreatedDomainEvent: BaseEvent
    {
        public Guid ShopperId { get; }
        public string ShopperName { get; }

        public CartCreatedDomainEvent(Guid cartId, Guid shopperId, string shopperName)
        {
            Id = cartId;
            ShopperId = shopperId;
            ShopperName = shopperName;
        }
    }
}
