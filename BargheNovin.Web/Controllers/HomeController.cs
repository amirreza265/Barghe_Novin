using AutoMapper;
using BargheNovin.Core.DTOs.Content;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.Core.Services.Interface;
using BargheNovin.Web.Areas.Admin.Models.PagiesContent;
using BargheNovin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageService _pageService;
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPageService pageService, IMapper mapper, IPortfolioService portfolioService)
        {
            _logger = logger;
            _pageService = pageService;
            _mapper = mapper;
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var pages = _pageService.GetPageContents("Services", "for-work", "work-samples", "customers");
            var pagesVM = _mapper.Map<List<PageViewModel>>(pages);

            var portfolio = _portfolioService.GetPortfolioWhere(showInMainPage:true);
            var portVM = _mapper.Map<List<MainPagePortfolioViewModel>>(portfolio);

            ViewData["Pages"] = pagesVM;
            ViewData["portfolio"] = portVM;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/contact-us")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ContactUs(MessageViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            model.Email += "amireaaaaasass";
            return Json(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/portfolio")]
        public IActionResult Portfolio()
        {
            var portfolio = _portfolioService.GetPortfolioWhere();
            var pvm = _mapper.Map<List<MainPagePortfolioViewModel>>(portfolio);
            var page = _pageService.GetPageContents("work-samples")[0];
            var pageVM = _mapper.Map<PageViewModel>(page);
            ViewData["WorkSamplesDescription"] =  pageVM.GetContent("WorkSamplesDescription");
            return View(pvm);
        }

        [Route("/show-portfolio/{id}")]
        public IActionResult ShowPortfolio(int id)
        {
            var port = _portfolioService.GetPortfolioBy(id);
            if (port == null)
                return NotFound();

            var portvm = _mapper.Map<ShowPortfolioViewModel>(port);
            return View(portvm);
        }
    }
}
