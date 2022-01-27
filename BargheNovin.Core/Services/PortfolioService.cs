using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.WorkSamples;
using Microsoft.AspNetCore.Http;
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

        public ListPageViewModel<Portfolio> GetPortfolioWhere(int pageId, int take = 20, string nameFilter = "", string categoryFilter = "", bool? showInMainPage = null)
        {
            IQueryable<Portfolio> result = GetPrtfolioQuery(nameFilter, categoryFilter, showInMainPage);

            if (take < 1)
                take = 20;
            int skip = (pageId - 1) * take;

            var list = new ListPageViewModel<Portfolio>()
            {
                CurrentPage = pageId,
                PageCount = (int)MathF.Ceiling((float)result.Count() / take),
                Data = result.OrderBy(p => p.PortfolioId).Skip(skip).Take(take).ToList()
            };

            return list;
        }

        private IQueryable<Portfolio> GetPrtfolioQuery(string nameFilter = "", string categoryFilter = "", bool? showInMainPage = null, bool includeCategory = true)
        {
            IQueryable<Portfolio> result = _context.Portfolio;

            if (includeCategory)
                result = result.Include(p => p.Category)
                   .AsSplitQuery();

            if (nameFilter != null && nameFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{nameFilter}%"));

            if (categoryFilter != null && categoryFilter != "")
                result = result.Where(p => EF.Functions.Like(p.Name, $"%{categoryFilter}%"));

            if (showInMainPage != null)
                result = result.Where(p => p.ShowInMainPage == showInMainPage);

            return result;
        }

        public List<Portfolio> GetPortfolioWhere(string nameFilter = "", string categoryFilter = "", bool? showInMainPage = null)
        {
            IQueryable<Portfolio> result = GetPrtfolioQuery(nameFilter, categoryFilter, showInMainPage);

            return result.ToList();
        }

        public List<Tuple<int, string>> GetGategories()
        {
            return _context.PortfolioCategories
                .Select(pc => new Tuple<int, string>(pc.CategoryId, pc.Name))
                .ToList();
        }

        public void UpdatePortfolioImage(ref Portfolio portfolio, IFormFile file, bool save = true)
        {
            portfolio.ImageName = UploadFile.ReplaceNew(file, portfolio.ImageName, null, "wwwroot", "main", "img", "portfolio");

            ImageResize.Resize(portfolio.ImageName, 360, 270, "wwwroot", "main", "img", "portfolio");

            Update(portfolio, save);
        }

        public Portfolio CreateNewPortfolio(InputPortfolioViewModel input, bool save = true)
        {
            Portfolio portfolio = new Portfolio
            {
                Name = input.Name,
                Description = input.Description,
                CategoryId = input.CategoryId,
                IsDeleted = false,
                ShowInMainPage = input.ShowInMainPage,
            };

            if (input.Image != null)
            {
                portfolio.ImageName = UploadFile.AddFile(input.Image, true,
                "wwwroot", "main", "img", "portfolio");

                ImageResize.Resize(portfolio.ImageName, 360, 270, "wwwroot", "main", "img", "portfolio");
            }
            _context.Portfolio.Add(portfolio);
            if (save)
                _context.SaveChanges();

            return portfolio;
        }

        public void Update<E>(E entity, bool save = true)
        {
            _context.Update(entity);

            if (save)
                _context.SaveChanges();
        }

        public Portfolio GetPortfolioBy(int id, bool includeCategory = true)
        {
            IQueryable<Portfolio> result = _context.Portfolio;

            if (includeCategory)
                result.Include(p => p.Category)
                    .AsSplitQuery();

            return result.SingleOrDefault(p => p.PortfolioId==id);
        }
    }
}
