using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ordering.API.Data.Entities;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly double[] Prices = new[]
        {
            45.23, 45.67, 12.64
        };

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Order
            {
                CreatedOnUtc = DateTime.Now.AddDays(index),
                OrderNo = rng.Next(-20, 55),
                Price = Convert.ToDecimal(Prices[rng.Next(Prices.Length)])
            })
            .ToArray();
        }
    }
}
