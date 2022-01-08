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
        public string Description { get; set; }

        public string ImageName { get; set; }

        [Display(Name = "عکس نمایشی")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile ImageUpload { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 1")]
        public string TextTitle1 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 1")]
        public string Text1 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 2")]
        public string TextTitle2 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 2")]
        public string Text2 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 3")]
        public string TextTitle3 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 3")]
        public string Text3 { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان 4")]
        public string TextTitle4 { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات 4")]
        public string Text4 { get; set; }
    }
}
