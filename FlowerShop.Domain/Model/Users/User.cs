using FlowerShop.Domain.Model.Baskits;
using FlowerShop.Domain.Model.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Users
{
    public class User: IdentityUser
    {
        [Display(Name = "فعال سازی")]
        public bool IsActive { get; set; }
        private readonly List<Comment> comments = new List<Comment>();
        public void AddComment(string Description,int ArticleId,long? ParentCategoryId)
        {
            comments.Add(new Comment(Description, ArticleId, Id, ParentCategoryId));
        }
        private readonly List<Address> addresses = new List<Address>();
        public void AddAddress(string City, string State, string ZipCode, string DesAddress, string UserId)
        {
            addresses.Add(new Address(City, State, ZipCode, DesAddress, Id));
        }
        private readonly List<Order> orders = new List<Order>();
        public void AddOrder(string Name, string MobilNumber, int TotalPrice, string City, string State, string ZipCode, string DesAddress, string UserId)
        {
            orders.Add(new Order(Name,MobilNumber,TotalPrice,City,State,ZipCode,DesAddress,Id));
        }
        private readonly List<Token> tokens = new List<Token>();
        public void AddToken(string HashToken, string RefreshToken, string UserId)
        {
            Tokens.Add(new Token(HashToken, RefreshToken, UserId));
        }
        #region 
        public virtual ICollection<Comment> Comments => comments;
        public virtual ICollection<Address> Addresses => addresses;
        public virtual ICollection<Order> Orders => orders;
        public virtual ICollection<Token> Tokens => tokens;
        public virtual Baskit Baskit { get; private set; }
        #endregion
    }
}
