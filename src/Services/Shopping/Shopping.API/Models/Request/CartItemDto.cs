using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Models.Request
{
    public class CartItemDto
    {
        #region Properties used for update

        public Guid CartItemId { get; set; }

        #endregion // Properties used for update

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
