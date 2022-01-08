using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface IPageService
    {
        int AddPage(string pageName);
        int AddContent(string pageName, string name, string content);
        void UpdateContent(string contentName, string newContent);
    }
}
