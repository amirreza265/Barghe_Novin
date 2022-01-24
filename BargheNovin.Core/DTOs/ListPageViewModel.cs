using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs
{
   public class ListPageViewModel<E>
    {
        public List<E> Data { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
