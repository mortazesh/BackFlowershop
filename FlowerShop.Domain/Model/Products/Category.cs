using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Products
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public long? ParentCategoryId { get; set; }
        public Category(string Name, int ProductId, long? ParentCategoryId)
        {
            this.Name = Name;
            this.ProductId = ProductId;
            this.ParentCategoryId = ParentCategoryId;
        }
        #region Relations
        public virtual Product Product { get; private set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual Category ParentCategory { get; private set; }  
        #endregion
    }
}
