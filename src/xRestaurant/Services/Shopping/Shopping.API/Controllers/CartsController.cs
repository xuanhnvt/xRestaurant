using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopping.API.Application.Commands.Cart;
using Shopping.API.Data.Entities;
using Shopping.API.Models.Request;
using xSystem.Core.Data;
using xSystem.Core.Helpers;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ILogger<CartsController> _logger;
        private readonly IEntityRepository<Cart> _repository;
        private readonly ICommandSender _commandSender;

        public CartsController(ILogger<CartsController> logger, IEntityRepository<Cart> repository,
            ICommandSender commandSender)
        {
            _logger = logger;
            _repository = repository;
            _commandSender = commandSender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _repository.Table.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCartDto model, CancellationToken cancellationToken)
        {
            try
            {
                Guid guid = GuidHelper.NewCompGuid();
                await _commandSender.Send(new CreateCartCommand(guid, model), cancellationToken);
                return Ok(guid);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Create Order: Exception Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("{id}/items")]
        public async Task<IActionResult> AddCartItem(Guid id, AddCartItemDto model, CancellationToken cancellationToken)
        {
            try
            {
                if (id != model.CartId)
                {
                    return BadRequest();
                }

                await _commandSender.Send(new AddCartItemCommand(id, model.Version, model.CartItem), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Add cart item: Exception Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
