using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.WorkSamples
{
    public class PortfolioCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string FilterName { get; set; }

        public List<Portfolio> Portfolio { set; get; }
    }
}
