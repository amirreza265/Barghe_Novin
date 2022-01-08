using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Controllers
{
    public class AccountController : Controller
    {
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
