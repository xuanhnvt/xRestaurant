using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Catalog.API.Services;

namespace Catalog.API.Factories
{
    public class ProductModelFactory: IProductModelFactory
    {
        private readonly ILogger<ProductModelFactory> _logger;
        private readonly IProductService _service;

        public ProductModelFactory(ILogger<ProductModelFactory> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
