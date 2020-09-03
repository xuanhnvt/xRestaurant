using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shipping.API.Data.Entities;

namespace Shipping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ShipmentsController> _logger;

        public ShipmentsController(ILogger<ShipmentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Shipment> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Shipment
            {
                CreatedOnUtc = DateTime.Now.AddDays(index),
                ShipmentNo = rng.Next(-20, 55),
                TrackingNumber = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
