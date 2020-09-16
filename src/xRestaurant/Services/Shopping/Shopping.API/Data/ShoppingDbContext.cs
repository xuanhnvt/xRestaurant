using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Data.Entities;
using xSystem.Core.Data;

namespace Shopping.API.Data
{
    public class ShoppingDbContext: DbContext, IShoppingDbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<DomainEvent> DomainEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<CartItem>().ToTable("CartItem").HasOne(ci => ci.Cart).WithMany(c => c.CartItems).HasForeignKey(c => c.CartId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DomainEvent>().ToTable("DomainEvent");
        }
    }
}
