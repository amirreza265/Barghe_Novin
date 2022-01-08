using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities
{
    public class LogoFiles
    {
        [Key]
        public int LogoId { get; set; }
        [MaxLength(150)]
        public string MainLogo { get; set; }
        [MaxLength(150)]
        public string FooterLogo { get; set; }
        [MaxLength(150)]
        public string SmallLogo { get; set; }
    }
}
