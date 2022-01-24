using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Portfolio
{
    public class MainPagePortfolioViewModel
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
