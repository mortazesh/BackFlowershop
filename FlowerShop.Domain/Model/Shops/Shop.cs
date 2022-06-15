using FlowerShop.Domain.Model.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Shops
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(20, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Name { get; private set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(10, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Description { get; private set; }
        public int ProductId { get; set; }
        public Shop(string Name, string Description, int ProductId)
        {
            this.Name = Name;
            this.Description = Description;
            this.ProductId = ProductId;
        }
        #region Relations
        public virtual Product Product { get; private set; }
        #endregion
    }
}
