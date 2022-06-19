using FlowerShop.Domain.Model.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Products
{
    public class Product
    {
        [Key]
        public int Id { set; get; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(10, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(20, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Name { private set; get; }
        [Display(Name = "توضیحات فروشگاه")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(10, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Description { get; private set; }
        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(2, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [Phone]
        public int Price { private set; get; }
        [Display(Name = "زمان")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public DateTime Created { private set; get; }
        [Display(Name = "تعداد محصول")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(1, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [Phone]
        public int Count { private set; get; }
        [Display(Name = "موجودیت")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public bool Exsit { private set; get; }
        public Product(string Name, string Description, int Price, int Count)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Count = Count;
            this.Created = DateTime.Now;
            this.Exsit = true;
        }
        private readonly List<Property> properties = new List<Property>();
        public void AddProperty(string Name, string Value)
        {
            properties.Add(new Property(Name, Value, Id));
        }
        private readonly List<Images> images = new List<Images>();
        public void AddImage(string UrlImage)
        {
            images.Add(new Images(UrlImage, Id));
        }
        private readonly List<Category> categories = new List<Category>();
        public void AddCategories(string Name,long? ParentCategoryId)
        {
            categories.Add(new Category(Name, Id, ParentCategoryId));
        }
        private readonly List<Comment> comments = new List<Comment>();
        public void AddComment(string Description, string UserId, long? ParentCategoryId)
        {
            comments.Add(new Comment(Description, Id, UserId, ParentCategoryId));
        }
        #region Relations
        public virtual ICollection<Property> Properties => properties;
        public virtual ICollection<Images> Images => images;
        public virtual ICollection<Category> Categories => categories;
        public virtual ICollection<Comment> Comments => comments;
        public virtual Shop Shop { get; private set; }
        public virtual Seos Seos { get; private set; }
        #endregion
    }
}
