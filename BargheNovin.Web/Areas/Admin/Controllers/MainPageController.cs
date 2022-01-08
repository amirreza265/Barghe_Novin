using AutoMapper;
using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs.Content;
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

            List<ContentDto> contents = new List<ContentDto>()
            {
                new ContentDto()
                {
                    ContentName = nameof(model.ServicesDescription),
                    Content = model.ServicesDescription
                },new ContentDto()
                {
                    ContentName = nameof(model.SText1),
                    Content = model.SText1
                },new ContentDto()
                {
                    ContentName = nameof(model.SText2),
                    Content = model.SText2
                },new ContentDto()
                {
                    ContentName = nameof(model.SText3),
                    Content = model.SText3
                },new ContentDto()
                {
                    ContentName = nameof(model.SText4),
                    Content = model.SText4
                },new ContentDto()
                {
                    ContentName = nameof(model.STextTitle1),
                    Content = model.STextTitle1
                },new ContentDto()
                {
                    ContentName = nameof(model.STextTitle2),
                    Content = model.STextTitle2
                },new ContentDto()
                {
                    ContentName = nameof(model.STextTitle3),
                    Content = model.STextTitle3
                },new ContentDto()
                {
                    ContentName = nameof(model.STextTitle4),
                    Content = model.STextTitle4
                }
            };
            List<ImageContentDto> images = new List<ImageContentDto>() { 
                new ImageContentDto()
                {
                    ImageFile = model.ImageUpload,
                    ImgKey = model.ImageKey
                }
            };

            _pageService.UpdatePageContents(model.PageName, contents, images);

            return RedirectToAction("Services");
        }
    }
}
