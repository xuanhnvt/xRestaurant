using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Events;

namespace Shopping.Domain.Events.Cart
{
    public class CartItemAddedDomainEvent: BaseEvent
    {
        public Guid CartItemId { get; }
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }

        public CartItemAddedDomainEvent(Guid cartId, Guid cartItemId, Guid productId, string productName, decimal unitPrice, int quantity)
        {
            Id = cartId;
            CartItemId = cartItemId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
