using BargheNovin.Core.Directories;
using BargheNovin.Web.Areas.Admin.Models;
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
            if (logos.MainLogo != null)
            {
                UploadFile.ReplaceFile(logos.MainLogo, "logo.png", "wwwroot", "main", "img");
                ImageResize.MakeSquerLogo("logo.png", 300, "wwwroot", "main", "img");
            }
            if (logos.FooterLogo != null)
            {
                UploadFile.ReplaceFile(logos.FooterLogo, "footer-logo.png", "wwwroot", "main", "img");
                ImageResize.MakeSquerLogo("footer-logo.png", 150, "wwwroot", "main", "img");
            }
            if (logos.SmallLogo != null)
            {
                UploadFile.ReplaceFile(logos.SmallLogo, "small-logo.png", "wwwroot", "main", "img");
                ImageResize.MakeSquerLogo("small-logo.png", 50, "wwwroot", "main", "img");
            }
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
            return View();
        }
    }
}
