using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Domain;
using Shopping.Domain.Events.Cart;

namespace Shopping.Domain.Aggregates.Cart
{
    public class Cart: AggregateRoot
    {
        private bool _activated;
        private readonly List<CartItem> _cartItems;
        public Guid ShopperId { get; private set; }
        public string ShopperName { get; private set; }

        #region Public Properties

        #endregion

        protected Cart()
        {
            _cartItems = new List<CartItem>();
        }

        public Cart(Guid id, Guid shopperId, string shopperName, List<CartItem> cartItems): this()
        {
            if (cartItems == null)
                throw new ArgumentNullException();

            ApplyChange(new CartCreatedDomainEvent(id, shopperId, shopperName, cartItems));
        }

        private void Apply(CartCreatedDomainEvent e)
        {
            _activated = true;
            Id = e.Id;
            ShopperId = e.ShopperId;
            ShopperName = e.ShopperName;
            foreach (var item in e.CartItems)
            {
                _cartItems.Add(new CartItem(item.Id, item.ProductId, item.ProductName, item.UnitPrice, item.Quantity));
            }
        }

        private void Apply(CartItemAddedDomainEvent e)
        {
            _cartItems.Add(new CartItem(e.CartItemId, e.ProductId, e.ProductName, e.UnitPrice, e.Quantity));
        }


        private void Apply(CartItemUpdatedDomainEvent e)
        {
            var item = _cartItems.Find(i => i.Id == e.CartItemId);
            if (item != null)
            {
                item.ProductId = e.ProductId;
                item.ProductName = e.ProductName;
                item.Quantity = e.Quantity;
                item.UnitPrice = e.UnitPrice;
            }
            else
            {
                throw new Exception(String.Format("No have item '{0}' in cart.", e.CartItemId));
            }
        }

        private void Apply(CartItemQuantityChangedDomainEvent e)
        {
            var item = _cartItems.Find(i => i.Id == e.CartItemId);
            if (item != null)
            {
                item.SetQuatity(e.Quantity);
            }
            else
            {
                throw new Exception(String.Format("No have item '{0}' in cart.", e.CartItemId));
            }
        }

        private void Apply(CartDeletedDomainEvent e)
        {
            _activated = false;
        }

        public void Delete()
        {
            if (!_activated) throw new InvalidOperationException("already deactivated");
            ApplyChange(new CartDeletedDomainEvent(Id));
        }

        public void AddCartItem(Guid cardItemId, Guid productId, string productName, decimal unitPrice, int quantity)
        {
            ApplyChange(new CartItemAddedDomainEvent(Id, cardItemId, productId, productName, unitPrice, quantity));
        }


        public void UpdateCartItem(Guid cardItemId, Guid productId, string productName, decimal unitPrice, int quantity)
        {
            ApplyChange(new CartItemUpdatedDomainEvent(Id, cardItemId, productId, productName, unitPrice, quantity));
        }

        public void ChangeCartItemQuantity(Guid cardItemId, int quantity)
        {
            ApplyChange(new CartItemQuantityChangedDomainEvent(Id, cardItemId, quantity));
        }
    }
}
