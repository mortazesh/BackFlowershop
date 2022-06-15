using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlowerShop.Domain.Model.Users;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model.Articles;
using FlowerShop.Domain.Model.Baskits;
using FlowerShop.Domain.Model.Orders;
using FlowerShop.Domain.Model.Products;
using FlowerShop.Domain.Model;
using FlowerShop.Domain.Model.Shops;

namespace FlowerShop.Persentation.Data
{
    public class DataBaseContext : IdentityDbContext<User,Role,string>, IDataBaseContext
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
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {

        }
    }
}
