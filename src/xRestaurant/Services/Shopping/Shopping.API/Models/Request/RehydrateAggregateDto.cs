using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Models.Request
{
    public class RehydrateAggregateDto
    {
        public Guid AggregateId { get; set; }
        public int FromVersion { get; set; }
    }
}
