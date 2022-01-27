using BargheNovin.Core.DTOs;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.DataLayer.Entities.WorkSamples;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface IPortfolioService
    {
        ListPageViewModel<Portfolio> GetPortfolioWhere(int pageId, int take=20, string nameFilter = "", string categoryFilter = "", bool? showInMainPage = null);
        List<Portfolio> GetPortfolioWhere(string nameFilter = "", string categoryFilter = "", bool? showInMainPage = null);

        List<Tuple<int, string>> GetGategories();

        /// <summary>
        /// replce image and return new image name
        /// </summary>
        /// <param name="portfolio">work sample</param>
        /// <param name="file">image file</param>
        /// <param name="save">save in data base</param>
        void UpdatePortfolioImage(ref Portfolio portfolio, IFormFile file, bool save = true);

        Portfolio CreateNewPortfolio(InputPortfolioViewModel input, bool save = true);

        void Update<E>(E entity, bool save = true); 
    }
}
