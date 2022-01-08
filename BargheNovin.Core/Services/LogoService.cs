using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs.Logo;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services
{
    public class LogoService : ILogoService
    {
        private dynamic _config;
        private JsonSerializerSettings jsonSettings;

        public LogoService()
        {
            Init();
        }

        private void Init()
        {
            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);

            jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            _config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
        }

        public void ChangeLogo(IFormFile main, IFormFile footer, IFormFile small)
        {
            if (main != null)
            {
                string mainName = _config.Logos.Main;
                mainName = UploadFile.ReplaceNew(main,mainName,new string[] { "logo.png" }, "wwwroot", "main", "img");
                ImageResize.MakeSquerImage(mainName, 300, "wwwroot", "main", "img");
                _config.Logos.Main = mainName;
            }
            if (footer != null)
            {
                string footerName = _config.Logos.Footer;
                footerName = UploadFile.ReplaceNew(main, footerName, new string[] { "footer-logo.png" }, "wwwroot", "main", "img");
                ImageResize.MakeSquerImage(footerName, 150, "wwwroot", "main", "img");
                _config.Logos.Footer = footerName;
            }
            if (small != null)
            {
                string smallName = _config.Logos.Small;
                smallName = UploadFile.ReplaceNew(main, smallName, new string[] { "small-logo.png" }, "wwwroot", "main", "img");
                ImageResize.MakeSquerImage(smallName, 50, "wwwroot", "main", "img");
                _config.Logos.Small = smallName;
            }
            UpdateLogoInConfig(_config);
        }

        public LogoFiles GetLogo()
        {
            var logos = new LogoFiles()
            {
                MainLogo = _config.Logos.Main,
                FooterLogo = _config.Logos.Footer,
                SmallLogo = _config.Logos.Small,
            };
           return logos;
        }

        private void UpdateLogoInConfig(dynamic config)
        {
            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");

            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingsPath, newJson);
        }
    }
}
