using BargheNovin.Core.DTOs.Logo;
using BargheNovin.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface ILogoService
    {
        LogoFiles GetLogo();
        void ChangeLogo(IFormFile main, IFormFile footer, IFormFile small);
    }
}
