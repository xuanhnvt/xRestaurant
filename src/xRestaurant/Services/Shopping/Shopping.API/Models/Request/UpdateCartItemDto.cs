using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Models.Request
{
    public class UpdateCartItemDto
    {
        public UpdateCartItemDto()
        {

        }

        public Guid CartId { get; set; }
        public Guid CartItemId { get; set; }
        public int Version { get; set; }
        public CartItemDto CartItem { get; set; }

        #region Nested classes

        #endregion
    }
}
