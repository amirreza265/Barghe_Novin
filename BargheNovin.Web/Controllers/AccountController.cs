using AutoMapper;
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
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        private JsonResult ModelErrors
        {
            get => Json(ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
