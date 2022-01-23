using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class InputPageContentViewModel
    {
        public int PageId { get; set; }
        public string DisplayName { get; set; }
        public string PageName { get; set; }
        public List<ContentDto> Contents { get; set; }
        public List<ImageContentDto> Images { get; set; }
    }
}
