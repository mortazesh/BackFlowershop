using FlowerShop.Domain.Model.Articles;
using FlowerShop.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
        public int ArticlesId { get; private set; }
        public string UserId { get; private set; }
        public long? ParentCategoryId { get; set; }
        public Comment(string Description,int ArticlesId,string UserId, long? ParentCategoryId)
        {
            this.Description = Description;
            this.ArticlesId = ArticlesId;
            Created = DateTime.Now;
            this.UserId = UserId;
            this.ParentCategoryId = ParentCategoryId;
        }
        #region Relations
        public virtual ICollection<Comment> SubComment { get; set; }
        public virtual Comment ParentComment { get; private set; }
        public virtual Article Article { get; private set; }
        public virtual User Users { get; private set; }
        #endregion
    }
}
