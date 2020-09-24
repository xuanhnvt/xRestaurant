using System;
using System.Collections.Generic;
using System.Text;
using xSystem.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace xSystem.Core.Data
{
    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EntityRepository<TEntity> : EntityRepositoryWithGenericId<TEntity, long>, IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        #endregion

        #region Ctor

        public EntityRepository(IDbContext context) : base(context)
        {

        }

        #endregion
    }
}
