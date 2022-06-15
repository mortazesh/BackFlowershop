using FlowerShop.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Orders
{
    public class Address
    {
        [Key]
        public int Id { get; private set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(30, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string City { get; private set; }
        [Display(Name = "استان")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(30, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string State { get; private set; }
        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(2, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(30, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string ZipCode { get; private set; }
        [Display(Name = "آدرس کامل")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(4, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(50, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string DesAddress { get; private set; }
        public string UserId { get; private set; }
        public Address(string City, string State, string ZipCode, string DesAddress, string UserId)
        {
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.DesAddress = DesAddress;
            this.UserId = UserId;
        }
        #region Relations
        public virtual User User { get; private set; } 
        #endregion
    }
}
