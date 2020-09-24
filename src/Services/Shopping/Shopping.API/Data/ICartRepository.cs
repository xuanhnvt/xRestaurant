using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xSystem.Core.Data;
using Shopping.API.Data.Entities;

namespace Shopping.API.Data
{
    public interface ICartRepository: IEntityRepositoryWithGenericId<Cart, Guid>
    {
    }
}
