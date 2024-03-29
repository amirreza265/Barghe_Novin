﻿using BargheNovin.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Portfolio
{
    public class InputPortfolioViewModel
    {
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name ="شناسه")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(300,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name ="نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "عکس نمایشی")]
        [FileMaxSize(Size = 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile Image { get; set; }

        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام عکس فعلی")]
        public string ImageName { get; set; }

        public bool ShowInMainPage { get; set; }

        public int CategoryId { get; set; }
    }
}
