using FlowerShop.Domain.Model.Articles;
using FlowerShop.Domain.Model.Products;
using FlowerShop.Domain.Model.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model
{
    public class Seos
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
        public int ArticleId { get; private set; }
        public int ProductId { get; private set; }
        public int ShopId { get; private set; }
        public Seos(string Description, int ArticleId, int ProductId,int ShopId)
        {
            this.Description = Description;
            this.ArticleId = ArticleId;
            this.Created = DateTime.Now;
            this.ProductId = ProductId;
            this.ShopId = ShopId;
        }
        #region MyRegion
        public virtual Article Article { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual Shop Shop { get; private set; }
        #endregion
    }
}
