using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.API.Data.Entities;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private static readonly double[] Prices = new[]
        {
            15.26, 33.43, 44.32
        };

        private readonly ILogger<CartsController> _logger;

        public CartsController(ILogger<CartsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Cart
            {
                CreatedOnUtc = DateTime.Now.AddDays(index),
                CartNo = rng.Next(-20, 55),
                Price =Convert.ToDecimal(Prices[rng.Next(Prices.Length)])
            })
            .ToArray();
        }
    }
}
