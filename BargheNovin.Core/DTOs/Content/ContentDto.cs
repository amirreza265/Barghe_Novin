using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Content
{
    public class ContentDto
    {
        public string ContentName { get; set; }
        public string Content { get; set; }

#nullable enable
        public string? ContentTitle { get; set; }
    }
}
