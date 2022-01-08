using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.PageContent
{
    public class PageContent
    {
        [Key]
        public int PageId { get; set; }
        [Required]
        [MaxLength(200)]
        public string PageName { get; set; }


        public List<Content> Contents { get; set; }
    }
}
