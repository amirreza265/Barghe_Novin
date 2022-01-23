using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class InputPageContentViewModel
    {

        public string PageName { get; set; }
        public List<ContentDto> Contents { get; set; }
        public List<ImageContentDto> Images { get; set; }
    }
}
