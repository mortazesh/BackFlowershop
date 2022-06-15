using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Domain.Model.Products
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(5, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Name { get; private set; }
        [Display(Name = "ویژگی")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(5, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Value { get; private set; }
        public int ProductId { get; private set; }
        public Property(string Name, string Value, int ProductId)
        {
            this.Name = Name;
            this.Value = Value;
            this.ProductId = ProductId;
        }
        #region Relations
        public virtual Product Product { get; private set; }
        #endregion
    }
}
