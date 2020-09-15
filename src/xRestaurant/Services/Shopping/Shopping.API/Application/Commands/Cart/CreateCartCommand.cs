using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.API.Models.Request;

namespace Shopping.API.Application.Commands.Cart
{
    public class CreateCartCommand: BaseCommand
    {
        public readonly CreateCartDto CommandModel;

        public CreateCartCommand(Guid id, CreateCartDto model)
        {
            Id = id;
            CommandModel = model ?? throw new ArgumentNullException();
        }
    }
}
