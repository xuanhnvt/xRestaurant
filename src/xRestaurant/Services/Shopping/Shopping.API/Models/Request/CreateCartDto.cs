using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Models.Request
{
    public class CreateCartDto
    {
        private List<CartItemDto> _addedCartItems;

        public CreateCartDto()
        {

        }

        public Guid ShopperId { get; set; }
        public string ShopperName { get; set; }

        public List<CartItemDto> AddedCartItems
        {
            get { return _addedCartItems ?? (_addedCartItems = new List<CartItemDto>()); }
            set { _addedCartItems = value; }
        }

        #region Nested classes

        public class CartItemDto
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }

        #endregion
    }
}
