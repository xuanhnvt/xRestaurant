using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using Microsoft.Extensions.Logging;
using Shopping.API.Application.Commands.Cart;
using Shopping.Domain.Aggregates.Cart;
using xSystem.Core.Helpers;

namespace Shopping.API.Application.CommandHandlers
{
    public class CartCommandHandler : ICommandHandler<CreateCartCommand>, ICommandHandler<AddCartItemCommand>
    {
        private readonly ISession _session;
        private readonly ILogger<CartCommandHandler> _logger;

        public CartCommandHandler(ISession session, ILogger<CartCommandHandler> logger)
        {
            _session = session;
            _logger = logger;
        }

        public async Task Handle(CreateCartCommand message)
        {
            var cartItems = message.CommandModel.CartItems.Select(i => new CartItem(GuidHelper.NewCompGuid(), i.ProductId, i.ProductName, i.UnitPrice, i.Quantity)).ToList();
            var cart = new Cart(message.Id, message.CommandModel.ShopperId, message.CommandModel.ShopperName, cartItems);
            await _session.Add(cart);
            await _session.Commit();
        }

        public async Task Handle(AddCartItemCommand message)
        {
            var cartItem = message.CommandModel ?? throw new ArgumentNullException();
            var cart = await _session.Get<Cart>(message.Id, message.ExpectedVersion);
            cart.AddCartItem(GuidHelper.NewCompGuid(), cartItem.ProductId, cartItem.ProductName, cartItem.UnitPrice, cartItem.Quantity);
            await _session.Commit();
        }
    }
}
