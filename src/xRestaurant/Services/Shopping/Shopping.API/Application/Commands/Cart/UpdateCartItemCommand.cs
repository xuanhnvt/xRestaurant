using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.API.Models.Request;

namespace Shopping.API.Application.Commands.Cart
{
    public class UpdateCartItemCommand : BaseCommand
    {
        public readonly CartItemDto CommandModel;

        public UpdateCartItemCommand(Guid cartId, int version, CartItemDto model)
        {
            Id = cartId;
            ExpectedVersion = version;
            CommandModel = model ?? throw new ArgumentNullException();
        }
    }
}
