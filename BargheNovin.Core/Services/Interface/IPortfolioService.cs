using BargheNovin.Core.DTOs;
using BargheNovin.DataLayer.Entities.WorkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface IPortfolioService
    {
        ListPageViewModel<Portfolio> GetPortfolioWhere(int pageId=1, int take=20, string nameFilter = "", string categoryFilter = "");
    }
}
