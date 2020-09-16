using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.API.Models.Request;

namespace Shopping.API.Application.Commands.Cart
{
    public class AddCartItemCommand : BaseCommand
    {
        public readonly CartItemDto CommandModel;

        public AddCartItemCommand(Guid id, int version, CartItemDto model)
        {
            Id = id;
            ExpectedVersion = version;
            CommandModel = model ?? throw new ArgumentNullException();
        }
    }
}
