using CQRSlite.Events;
using Newtonsoft.Json;
using Shopping.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using xSystem.Core.Data;
using xSystem.Core.Helpers;

namespace Shopping.API.Data
{
    public class ShoppingDomainEventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;
        private readonly IEntityRepositoryWithGenericId<DomainEvent, long> _eventReposiory;
        private readonly Dictionary<Guid, List<IEvent>> _inMemoryDb = new Dictionary<Guid, List<IEvent>>();

        public ShoppingDomainEventStore(IEventPublisher publisher, IEntityRepositoryWithGenericId<DomainEvent, long> eventReposiory)
        {
            _publisher = publisher;
            _eventReposiory = eventReposiory;
        }

        public async Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            foreach (var @event in events)
            {
                DomainEvent entity = new DomainEvent()
                {
                    AggregateId = @event.Id,
                    Version = @event.Version,
                    TimeStamp = @event.TimeStamp,
                    EventType = @event.GetType().ToString(),
                    Data = JsonConvert.SerializeObject(@event)
                };
                await _eventReposiory.InsertAsync(entity);
                await _publisher.Publish(@event, cancellationToken);
            }
        }

        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default)
        {
            IEnumerable<IEvent> events = _eventReposiory.Table.Where(e => e.AggregateId == aggregateId)
                .Select(o => (IEvent) JsonConvert.DeserializeObject(o.Data, TypeHelper.GetType(o.EventType)));
            return Task.FromResult(events?.Where(x => x.Version > fromVersion) ?? new List<IEvent>());
        }
    }
}