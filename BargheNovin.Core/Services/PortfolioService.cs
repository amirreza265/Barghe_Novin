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

        public ListPageViewModel<Portfolio> GetPortfolioWhere(int pageId = 1, int take = 20, string nameFilter = "", string categoryFilter = "")
        {
            IQueryable<Portfolio> result = _context.Portfolio
                .Include(p => p.Category)
                .AsSplitQuery();

            if (nameFilter != null && nameFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{nameFilter}%"));

            if (categoryFilter != null && categoryFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{categoryFilter}%"));

            if (take < 1)
                take = 20;
            int skip = (pageId - 1) * take;

            var list = new ListPageViewModel<Portfolio>()
            {
                CurrentPage = pageId,
                PageCount = (int)MathF.Ceiling(result.Count() / take),
                Data = result.Skip(skip).Take(take).ToList()
            };

            return list;
        }
    }
}
