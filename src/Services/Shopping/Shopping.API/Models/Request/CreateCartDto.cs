using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Models.Request
{
    public class CreateCartDto
    {
        private List<CartItemDto> _cartItems;

        public CreateCartDto()
        {

        }

        public Guid ShopperId { get; set; }
        public string ShopperName { get; set; }

        public List<CartItemDto> CartItems
        {
            get { return _cartItems ?? (_cartItems = new List<CartItemDto>()); }
            set { _cartItems = value; }
        }

        #region Nested classes

        #endregion
    }
}
