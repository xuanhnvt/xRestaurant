using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Aggregates.Cart
{
    public class CartItem
    {
        public Guid Id { get; internal set; }
        public Guid ProductId { get; internal set; }
        public string ProductName { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal UnitPrice { get; internal set; }

        public CartItem(Guid cartItemId, Guid productId, string productName, decimal unitPrice, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Invalid quantity number");
            }

            Id = cartItemId;
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void SetQuatity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
