using System;
using System.Collections.Generic;
using System.Text;

namespace xSystem.Core.Data.Entities
{
    /// <summary>
    /// Define key property of base entity
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    public interface IEntityId<TKey>
    {
        TKey Id { get; set; }
    }
}
