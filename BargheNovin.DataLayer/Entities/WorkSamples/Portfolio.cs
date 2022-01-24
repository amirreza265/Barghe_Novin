using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.WorkSamples
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        
        [MaxLength(150)]
        [Required]
        public string ImageName { get; set; }

        [MaxLength(300)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public PortfolioCategory Category { get; set; }
    }
}
