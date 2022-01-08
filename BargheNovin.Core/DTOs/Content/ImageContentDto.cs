using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class ImageContentDto
    {
        public string ImgKey { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
