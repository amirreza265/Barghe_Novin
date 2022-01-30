using BargheNovin.Core.DTOs.Content;
using BargheNovin.DataLayer.Entities.PageContent;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface IPageService
    {
        public PageContent AddPage(string pageName, bool save = true);
        public Content AddContent(string pageName, string name, string contentHtml, bool save = true);
        void UpdateContent(string contentName, string newContent);

        int GetPageIdBy(string PageName);

        PageContent GetPageContentBy(string pageName);

        List<PageContent> GetPageContents(params string[] names);

        /// <summary>
        /// list of pages names
        /// </summary>
        /// <param name="filterName">filter name</param>
        /// <returns>name, displayname, id</returns>
        List<Tuple<string, string, int>> GetPageNames(string filterName = "");

        public ImageContent AddImageContent(string pagename, string imgKey, IFormFile image, bool save = true);
        void UpdateImageContent(string imgKey, IFormFile image);

        void UpdatePageContents(string pageName, List<ContentDto> contents, List<ImageContentDto> images, bool save = true);
    }
}
