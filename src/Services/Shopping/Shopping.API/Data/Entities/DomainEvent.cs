using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data.Entities
{
    public class DomainEvent : BaseEntity
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string EventType { get; set; }
        public string Data { get; set; }
    }
}
