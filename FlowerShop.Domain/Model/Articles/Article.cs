using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Articles
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; private set; } 
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string UrlImage { get; private set; }
        private readonly List<Comment> comments = new List<Comment>();
        public Article(string Title,string Description,string Author,string UrlImage)
        {
            this.Title = Title;
            this.Description = Description; 
            this.Author = Author;   
            this.UrlImage = UrlImage;   
        }
        public void AddComment(string Description,string UserId,long? ParentCategoryId)
        {
            comments.Add(new Comment(Description, Id, UserId, ParentCategoryId));
        }
        #region Relations
        public virtual ICollection<Comment> Comment => comments;
        public virtual Seos Seos { get; private set; }
        #endregion
    }
}
