using AutoMapper;
using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(InputPortfolioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Todo: create new
            _portfolioService.CreateNewPortfolio(model);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (!(upload?.Length > 0))
                return null;

            var name = UploadFile.AddFile(upload, true, "wwwroot", "main", "img", "uploaded" );

            var url = $"/main/img/uploaded/{name}";

            return Json(new { uploaded = true, url });
        }

        [Route("admin/change-show/{id}/{showInMain}")]
        public IActionResult ChangeShow(int id, bool showInMain)
        {
            var p = _portfolioService.GetPortfolioBy(id);
            p.ShowInMainPage = showInMain;
            _portfolioService.Update(p);

            return Json(new { id = id, showInMain = p.ShowInMainPage });
        }
    }
}
