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
                Guid guid = new Guid();
                await _commandSender.Send(new CreateCartCommand(guid, model), cancellationToken);
                return Ok(guid);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Create Order: Exception Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
