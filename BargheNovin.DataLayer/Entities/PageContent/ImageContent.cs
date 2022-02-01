using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.PageContent
{
   public class ImageContent
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public int PageId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ImageName { get; set; }

#nullable enable
        [MaxLength(400)]
        public string? ContentTitle { get; set; }
#nullable disable

        [Required]
        [MaxLength(150)]
        public string ImageKey { get; set; }

        [ForeignKey("PageId")]
        public PageContent PageContent { get; set; }
    }
}
