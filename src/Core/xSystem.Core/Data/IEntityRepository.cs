using System;
using System.Collections.Generic;
using System.Text;
using xSystem.Core.Data.Entities;

namespace xSystem.Core.Data
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IEntityRepository<TEntity> : IEntityRepositoryWithGenericId<TEntity, long> where TEntity : BaseEntity
    {

    }
}
