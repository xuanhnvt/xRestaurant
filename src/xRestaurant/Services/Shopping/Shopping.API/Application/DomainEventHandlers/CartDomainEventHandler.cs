using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Events;
using Microsoft.Extensions.Logging;
using Shopping.API.Data.Entities;
using Shopping.Domain.Events.Cart;
using xSystem.Core.Data;

namespace Shopping.API.Application.DomainEventHandlers
{
    public class CartDomainEventHandler : ICancellableEventHandler<CartCreatedDomainEvent>,
        ICancellableEventHandler<CartItemAddedDomainEvent>
    {
        private readonly ILogger<CartDomainEventHandler> _logger;
        private readonly IEntityRepository<Cart> _repository;
        private readonly IEntityRepository<CartItem> _cartItemrepository;

        public CartDomainEventHandler(ILogger<CartDomainEventHandler> logger, IEntityRepository<Cart> repository, IEntityRepository<CartItem> cartItemrepository)
        {
            _logger = logger;
            _repository = repository;
            _cartItemrepository = cartItemrepository;
        }

        public async Task Handle(CartCreatedDomainEvent message, CancellationToken token)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            var cart = new Cart()
            {
                Id = message.Id,
                CartNo = 1,
                Price = 0,
                ShopperName = message.ShopperName,
                ShopperId = message.ShopperId,
                CreatedOnUtc = message.TimeStamp.UtcDateTime,
                UpdatedOnUtc = message.TimeStamp.UtcDateTime,
                Version = message.Version
            };

            foreach(var item in message.CartItems)
            {
                cart.CartItems.Add(new CartItem()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    CartId = message.Id,
                    CreatedOnUtc = message.TimeStamp.UtcDateTime,
                    UpdatedOnUtc = message.TimeStamp.UtcDateTime
                });
            }

            await _repository.InsertAsync(cart);
        }

        public async Task Handle(CartItemAddedDomainEvent message, CancellationToken token)
        {
            // get cart
            var cart = await _repository.GetByIdAsync(message.Id);
            cart.Version = message.Version;
            cart.UpdatedOnUtc = message.TimeStamp.UtcDateTime;
            var cartItem = new CartItem()
            {
                Id = message.CartItemId,
                CartId = message.Id,
                ProductId = message.ProductId,
                ProductName = message.ProductName,
                UnitPrice = message.UnitPrice,
                Quantity = message.Quantity,
                CreatedOnUtc = message.TimeStamp.UtcDateTime,
                UpdatedOnUtc = message.TimeStamp.UtcDateTime
            };
            await _cartItemrepository.InsertAsync(cartItem);
            //cart.CartItems.Add(cartItem);
            await _repository.UpdateAsync(cart);
        }
    }
}
