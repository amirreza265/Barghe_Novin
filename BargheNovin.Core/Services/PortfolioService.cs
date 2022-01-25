using BargheNovin.Core.DTOs;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.WorkSamples;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly BargheNovinDBContext _context;

        public PortfolioService(BargheNovinDBContext context)
        {
            _context = context;
        }

        public ListPageViewModel<Portfolio> GetPortfolioWhere(int pageId, int take = 20, string nameFilter = "", string categoryFilter = "")
        {
            IQueryable<Portfolio> result = GetPrtfolioQuery(nameFilter, categoryFilter);

            if (take < 1)
                take = 20;
            int skip = (pageId - 1) * take;

            var list = new ListPageViewModel<Portfolio>()
            {
                CurrentPage = pageId,
                PageCount = (int)MathF.Ceiling((float)result.Count() / take),
                Data = result.Skip(skip).Take(take).ToList()
            };

            return list;
        }

        private IQueryable<Portfolio> GetPrtfolioQuery(string nameFilter = "", string categoryFilter = "", bool includeCategory = true)
        {
            IQueryable<Portfolio> result = _context.Portfolio;

            if (includeCategory)
                result = result.Include(p => p.Category)
                   .AsSplitQuery();

            if (nameFilter != null && nameFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{nameFilter}%"));

            if (categoryFilter != null && categoryFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{categoryFilter}%"));

            return result;
        }

        public List<Portfolio> GetPortfolioWhere(string nameFilter = "", string categoryFilter = "")
        {
            IQueryable<Portfolio> result = GetPrtfolioQuery(nameFilter, categoryFilter);

            return result.ToList();
        }

        public List<Tuple<int, string>> GetGategories()
        {
            return _context.PortfolioCategories
                .Select(pc => new Tuple<int, string>(pc.CategoryId, pc.Name))
                .ToList();
        }
    }
}
