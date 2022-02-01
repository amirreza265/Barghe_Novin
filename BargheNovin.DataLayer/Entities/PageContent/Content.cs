using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.PageContent
{
    public class Content
    {
        public int ContentId { get; set; }
        [Required]
        public int ContentNameId { get; set; }
        [Required]
        public int PageId { get; set; }
        public string ContentHtml { get; set; }

#nullable enable
        [MaxLength(400)]
        public string? ContentTitle { get; set; }
#nullable disable        

        public ContentName ContentName { get; set; }

        [ForeignKey("PageId")]
        public PageContent PageContent { get; set; }
    }
}
