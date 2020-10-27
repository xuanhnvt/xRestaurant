using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalog.API.Data.Entities;
using Catalog.API.Data;
using Microsoft.EntityFrameworkCore;
using xSystem.Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using xSystem.Core.Paginations;
using Catalog.API.Services;
using Catalog.API.Models.Responses;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly CatalogDbContext _dbContext;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, CatalogDbContext dbContext, IProductService productService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _productService = productService;
        }

        /// <summary>
        /// Get list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductPagedListDto>> GetProducts([FromQuery] int pageSize = 4, [FromQuery] int pageIndex = 0)
        {
            var products = await _productService.SearchProductsAsync(pageIndex, pageSize);
            var productListModel = new ProductPagedListDto();
            productListModel.LoadPagedList(products, () =>
            {
                return products.Select(p =>
                {
                    return new ProductPagedListDto.ProductListItem()
                    {
                        Sku = p.Sku,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        ProductNo = p.ProductNo,
                        StockQuantity = p.StockQuantity
                    };
                });
            });
            return productListModel;
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /products
        ///     {
        ///        "sku": "abc123",
        ///        "name": "Sample Product",
        ///        "description": "This is sample product",
        ///        "price": 3.4
        ///     }
        ///
        /// </remarks>
        /// <param name="product"></param>
        /// <returns>A newly created product</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.1")]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Delete a specific product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(Guid id)
        {
            return _dbContext.Products.Any(e => e.Id == id);
        }
    }
}
