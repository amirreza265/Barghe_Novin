using Microsoft.AspNetCore.Http;
using BargheNovin.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BargheNovin.Web.Areas.Admin.Models
{
    public class UploadLogosViewModel
    {
        [Display(Name ="لوگو اصلی")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile MainLogo { get; set; }

        [Display(Name = "لوگو پایین صفحه")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile FooterLogo { get; set; }

        [Display(Name = "لوگو کوچک")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile SmallLogo { get; set; }
    }
}
