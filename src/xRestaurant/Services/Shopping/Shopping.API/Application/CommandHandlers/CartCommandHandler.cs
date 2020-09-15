using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using Microsoft.Extensions.Logging;
using Shopping.API.Application.Commands.Cart;
using Shopping.Domain.Aggregates.Cart;

namespace Shopping.API.Application.CommandHandlers
{
    public class CartCommandHandler : ICommandHandler<CreateCartCommand>
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
            var order = new Cart(message.Id, message.CommandModel.ShopperId, message.CommandModel.ShopperName);
            foreach (var item in message.CommandModel.AddedCartItems)
            {
                order.AddCartItem(item.ProductId, item.ProductName, item.UnitPrice, item.Quantity);
            }
            await _session.Add(order);
            await _session.Commit();
        }
    }
}
