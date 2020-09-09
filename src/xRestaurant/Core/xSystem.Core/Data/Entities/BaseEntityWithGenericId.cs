using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xSystem.Core.Data.Entities
{
    /// <summary>
    /// Base generic class for entities
    /// </summary>
    public abstract class BaseEntityWithGenericId<TKey> : IEntityId<TKey>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
