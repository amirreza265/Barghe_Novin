using AutoMapper;
using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs;
using BargheNovin.Core.DTOs.Portfolio;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.Entities.WorkSamples;
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
            var portVm = _mapper.Map<List<MainPagePortfolioViewModel>>(port);
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

            var name = UploadFile.AddFile(upload, true, "wwwroot", "main", "img", "uploaded");

            var url = $"/main/img/uploaded/{name}";

            return Json(new { uploaded = true, url });
        }

        [Route("admin/change-show/{id}/{showInMain}")]
        public IActionResult ChangeShow(int id, bool showInMain)
        {
            var p = _portfolioService.GetPortfolioBy(id);

            if (p == null)
                return Json(false);

            p.ShowInMainPage = showInMain;
            _portfolioService.Update(p);

            return Json(new { id = id, showInMain = p.ShowInMainPage });
        }


        public IActionResult Delete(int id)
        {
            try
            {
                _portfolioService.DeletePortfolio(id);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }


        public IActionResult Edit(int id)
        {
            var port = _portfolioService.GetPortfolioBy(id);

            if (port == null)
                return NotFound();

            var portVm = _mapper.Map<InputPortfolioViewModel>(port);
            return View(portVm);
        }

        [HttpPost]
        public IActionResult Edit(InputPortfolioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var port = _mapper.Map<Portfolio>(model);

            if (model.Image?.Length > 0)
                _portfolioService.UpdatePortfolioImage(ref port, model.Image, false);
            _portfolioService.Update(port);

            return RedirectToAction("index");
        }

        public IActionResult Categories()
        {
            var cats = _portfolioService.GetPortfolioCategories();
            return View(cats);
        }

        [HttpPost]
        public IActionResult EditCategory(InputCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(ModelState.Values.SelectMany(val => val.Errors.Select(e => e.ErrorMessage)));

            var cat = _portfolioService.GetPortfolioCategoryBy(model.CategoryId);

            if (cat == null)
                return Json("گروه مورد نظر یافت نشد");

            if (cat.FilterName != model.FilterName && _portfolioService.GetPortfolioCategoryBy(model.FilterName) != null)
                return Json("نام فیلتر وارد شده تکراری . از نامی دیگر استفاده کنید");

            cat.FilterName = model.FilterName;
            cat.Name = model.Name;

            _portfolioService.Update(cat);

            return Json(true);
        }

        [HttpPost]
        public IActionResult CreateCategory(InputCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(ModelState.Values.SelectMany(val => val.Errors.Select(e => e.ErrorMessage)));

            var category = _mapper.Map<PortfolioCategory>(model);
            category.CategoryId = 0;
            _portfolioService.Create(category);

            return Json(true);
        }
    }
}
