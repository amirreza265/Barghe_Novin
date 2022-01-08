using AutoMapper;
using BargheNovin.Core.Directories;
using BargheNovin.Core.Services.Interface;
using BargheNovin.Web.Areas.Admin.Models;
using BargheNovin.Web.Areas.Admin.Models.PagiesContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainPageController : Controller
    {
        private readonly ILogoService _logoService;
        private readonly IPageService _pageService;
        private readonly IMapper _mapper;

        public MainPageController(ILogoService logoService, IPageService pageService, IMapper mapper)
        {
            this._logoService = logoService;
            _pageService = pageService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Logo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logo(UploadLogosViewModel logos)
        {
            if (!ModelState.IsValid)
                return View(logos);

            //try
            //{
            _logoService.ChangeLogo(logos.MainLogo,logos.FooterLogo,logos.SmallLogo);
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("", "ذخیره تصاویر با مشکل روبه رو شد.");
            //    return View(logos);
            //}
            return View();
        }

        public IActionResult Services()
        {
            var page = _pageService.GetPageContentBy("Services");
            var pageVM = _mapper.Map<ServicesPageContentViewModel>(page);
            return View(pageVM);
        }

        [HttpPost]
        public IActionResult Services(ServicesPageContentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);



            return RedirectToAction("Services");
        }
    }
}
