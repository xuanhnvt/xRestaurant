using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Data;
using Shopping.API.Data.Entities;
using xSystem.Core.Data;
using xSystem.Core.Data.Entities;

namespace Shopping.API.Data
{
    /// <summary>
    /// Represents an entity repository with generic key
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Key type of entity</typeparam>
    public class CartRepository : EntityRepositoryWithGenericId<Cart, Guid>, ICartRepository
    {
        #region Fields

        #endregion

        #region Ctor

        public CartRepository(IShoppingDbContext context): base(context)
        {

        }

        #endregion

        #region Override Methods

        
        /// <summary>
        /// Asynchronously update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task AddCartItemAsync(Cart entity, CartItem cartItem)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                //var existingCart = Entities.Include(e => e.CartItems)
                    //.FirstOrDefault(e => e.Id == entity.Id);
                var entry = DbContext.Entry(cartItem);
                entry.State = EntityState.Added;

                //existingCart.CartItems.Add(cartItem);

                //if (existingCart == null)
                //{
                //    await Entities.AddAsync(entity);
                //}
                //else
                //{
                //    DbContext.Entry(existingCart).CurrentValues.SetValues(entity);
                //    foreach (var item in entity.CartItems)
                //    {
                //        var existingItem = existingCart.CartItems
                //            .FirstOrDefault(p => p.Id == item.Id);

                //        if (existingItem == null)
                //        {
                //            existingCart.CartItems.Add(item);
                //        }
                //        else
                //        {
                //            DbContext.Entry(existingItem).CurrentValues.SetValues(item);
                //        }
                //    }
                //}

                //Entities.Update(entity);
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        #endregion
    }
}
