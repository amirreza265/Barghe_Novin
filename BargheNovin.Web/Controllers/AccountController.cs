using AutoMapper;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.Entities.User;
using BargheNovin.Web.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BargheNovin.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Register
        [Route("/register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return ModelErrors;
            }
            var user = _mapper.Map<User>(model);
            user = _userService.RegisterUser(user);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری یا ایمیل موجود است");
                return ModelErrors;
            }
            return Json(true);
        }
        #endregion

        #region Login
        [Route("/login/{ReturnUrl?}")]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return ModelErrors;
            }

            var user = _userService.LoginUser(model.UserIndex, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات یافت نشد . لطفا در وارد کردن نام و کلمه عبور دقت کنید");
                return ModelErrors;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { IsPersistent = true });

            return Json(true);
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }
        #endregion

        private JsonResult ModelErrors
        {
            get => Json(ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
