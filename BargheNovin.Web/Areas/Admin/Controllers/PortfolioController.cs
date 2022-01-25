using AutoMapper;
using BargheNovin.Core.DTOs;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var port = _portfolioService.GetPortfolioWhere();
            var portVm = _mapper.Map <List<MainPagePortfolioViewModel>>(port);
            return View(portVm);
        }
    }
}
