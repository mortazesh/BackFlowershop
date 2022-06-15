﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Users
{
    public class SmsCode
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [MinLength(11, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        [MaxLength(11, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        [RegularExpression(@"(\+98|0)?9\d{9}")]
        [Phone(ErrorMessage = "لطفا {0} را درست وارد کنید")]
        public string MobileNumber { get; private set; }
        [Display(Name = "کد فعال سازی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [MinLength(6, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        [MaxLength(6, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        public string Code { get; private set; }
        [Display(Name = "استفاده شده")]
        public bool Used { get; private set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime Created { get; private set; }
        [Display(Name = "دفعات استفاده شده")]
        public int RequertCount { get; private set; }
        public SmsCode(string MobileNumber, string Code)
        {
            this.MobileNumber = MobileNumber;
            this.Code = Code;
            this.Created = DateTime.Now;
            this.Used = false;
            this.RequertCount = 0;
        }
        public void AddSmsCode()
        {
            this.RequertCount++;
            this.Used = true;
        }
    }
}
