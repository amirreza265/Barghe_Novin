using BargheNovin.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class ImageContentDto
    {
        public string ImgKey { get; set; }
        public string ImageName { get; set; }

        [Display(Name = "عکس نمایشی")]
        [FileMaxSize(Size = 3 * 1024 * 1024, ErrorMessage = "حجم فایل {0} نمی تواند بیشتر از {1} باشد")]
        [AllowedExtensions(extensions: new string[] { ".jpg", ".png", ".jpeg" }, ErrorMessage = "پسوند تصویر باید {1} باشد")]
        public IFormFile ImageFile { get; set; }

#nullable enable
        public string? ContentTitle { get; set; }
    }
}
