using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.PageContent
{
    public class ContentName
    {
        public int ContentNameId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        public Content Content { get; set; }
    }
}
