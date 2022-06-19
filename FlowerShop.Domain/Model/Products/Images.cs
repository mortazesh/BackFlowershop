using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Products
{
    public class Images
    {
        [Key]
        public int Id { get; set; }
        public string UrlImage { get; private set; }
        public int ProductId { get; private set; }
        public Images(string UrlImage,int ProductId)
        {
            this.UrlImage = UrlImage;
            this.ProductId = ProductId;
        }
        #region Relations
        public virtual Product Product { get; private set; }
        #endregion
    }
}
