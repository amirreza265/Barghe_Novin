using BargheNovin.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Areas.Admin.Models.PagiesContent
{
    public class ServicesPageContentViewModel
    {

        public string PageName { get; set; }
        
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name =" توضیحات اولیه")]
        public string ServicesDescription { get; set; }

        public string ImageName { get; set; }
        public string ImageKey { get; set; }

        [Display(Name = "عکس نمایشی")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile ImageUpload { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 1")]
        public string STextTitle1 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 1")]
        public string SText1 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 2")]
        public string STextTitle2 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 2")]
        public string SText2 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 3")]
        public string STextTitle3 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 3")]
        public string SText3 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 4")]
        public string STextTitle4 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 4")]
        public string SText4 { get; set; }
    }
}
