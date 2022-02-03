using BargheNovin.Core.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Attributes
{
    public class AdminPanelAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserService userService;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectResult("/Login");

            string username = context.HttpContext.User.Identity.Name;
            userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

            var user = userService.GetUserByUsername(username);
            
            if (user == null)
                context.Result = new RedirectResult("/Login");

            if (!user.IsAdmin)
                context.Result = new ForbidResult(CookieAuthenticationDefaults.AuthenticationScheme);
            
        }
    }
}
