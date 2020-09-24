using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Events;
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
    public class AggregatesController : ControllerBase
    {
        private readonly ILogger<AggregatesController> _logger;
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _eventPublisher;

        public AggregatesController(ILogger<AggregatesController> logger, IEventStore eventStore,
        IEventPublisher eventPublisher)
        {
            _logger = logger;
            _eventStore = eventStore;
            _eventPublisher = eventPublisher;
        }

        [HttpPut("{id}/events")]
        public async Task<IActionResult> RehydrateAggregate(Guid id, RehydrateAggregateDto model, CancellationToken cancellationToken)
        {
            try
            {
                if (id != model.AggregateId)
                {
                    return BadRequest();
                }

                var events = await _eventStore.Get(model.AggregateId, model.FromVersion, cancellationToken);
                foreach(var evt in events)
                {
                    await _eventPublisher.Publish(evt, cancellationToken);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Rehydrate aggregate: Exception Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
