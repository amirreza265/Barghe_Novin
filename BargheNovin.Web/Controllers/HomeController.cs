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
            var pages = _pageService.GetPageContents(new List<string>() { "Services", "for-work", "work-samples" });
            var pagesVM = _mapper.Map<List<PageViewModel>>(pages);

            var portfolio = _portfolioService.GetPortfolioWhere(pageId: 1, take: 6);
            var portVM = _mapper.Map<List<MainPagePortfolioViewModel>>(portfolio.Data);

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
        public IActionResult ContactUs(MessageViewModel message)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            message.Email += "amireaaaaasass";
            return Json(message);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
