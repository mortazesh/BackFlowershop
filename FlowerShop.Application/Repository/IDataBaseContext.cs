using FlowerShop.Domain.Model;
using FlowerShop.Domain.Model.Articles;
using FlowerShop.Domain.Model.Baskits;
using FlowerShop.Domain.Model.Orders;
using FlowerShop.Domain.Model.Products;
using FlowerShop.Domain.Model.Shops;
using FlowerShop.Domain.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.Application.Repository
{
    public interface IDataBaseContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Baskit> Baskits { get; set; }
        public DbSet<BaskitItem> BaskitItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<SmsCode> SmsCodes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Seos> Seos { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        EntityEntry Entry([NotNullAttribute] object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}
