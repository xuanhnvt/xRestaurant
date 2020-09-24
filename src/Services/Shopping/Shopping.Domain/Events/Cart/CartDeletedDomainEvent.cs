using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Events.Cart
{
    public class CartDeletedDomainEvent: BaseEvent
    {
        public CartDeletedDomainEvent(Guid cartId)
        {
            Id = cartId;
        }
    }
}
