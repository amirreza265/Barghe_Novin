using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class PageViewModel
    {
        public string PageName { get; set; }
        public List<ContentDto> Contents { get; set; }
        public List<ShowImageViewModel> ImageContents { get; set; }

        public string GetContent(string contentName)
        {
            if (Contents == null || Contents.Count <= 0)
                return "";

            return this.Contents.Find(cn => cn.ContentName.Equals(contentName)).Content;
        }
        public string GetImage(string imageKey)
        {
            if (ImageContents == null || ImageContents.Count <= 0)
                return "";

            return this.ImageContents.Find(cn => cn.ImageKey.Equals(imageKey)).ImageName;
        }
    }
}
