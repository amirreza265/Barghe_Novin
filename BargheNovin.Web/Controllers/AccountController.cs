using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.Entities.User;
using BargheNovin.Web.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Register
        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userService.Any(u => u.UserName == model.UserName || u.Email == model.Email))
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری یا ایمیل موجود است");
                return View(model);
            }



            return View(model);
        }
        #endregion

        #region Login
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
        #endregion
    }
}
