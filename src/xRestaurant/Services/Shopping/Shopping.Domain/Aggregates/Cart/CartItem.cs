using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Aggregates.Cart
{
    public class CartItem
    {
        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public CartItem(Guid productId, string productName, decimal unitPrice, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Invalid quantity number");
            }

            Id = productId;
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
