using BargheNovin.Core.Directories;
using BargheNovin.Core.DTOs.Content;
using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.PageContent;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services
{
    public class PageService : IPageService
    {
        private readonly BargheNovinDBContext _context;

        public PageService(BargheNovinDBContext context)
        {
            _context = context;
        }

        public Content AddContent(string pageName, string name, string contentHtml, bool save = true)
        {
            int pageId = 0;
            try
            {
                pageId = GetPageIdBy(pageName);
            }
            catch (Exception e)
            {
                pageId = AddPage(pageName).PageId;
            }

            ContentName contentName = new ContentName()
            {
                Name = name
            };

            Content content = new Content()
            {
                ContentHtml = contentHtml,
                ContentName = contentName,
                PageId = pageId,
            };
            _context.Contents.Add(content);

            if (save)
                _context.SaveChanges();

            return content;
        }

        public ImageContent AddImageContent(string pagename, string imgKey, IFormFile image, bool save=true)
        {
            var img = new ImageContent()
            {
                ImageKey = imgKey,
                PageId = GetPageIdBy(pagename),
                ImageName = UploadFile.AddFile(image, true, "wwwroot", "main", "img"),
            };

            _context.ImageContents.Add(img);

            if (save)
                _context.SaveChanges();

            return img;
        }

        public PageContent AddPage(string pageName, bool save = true)
        {
            var page = new PageContent()
            {
                PageName = pageName
            };

            _context.PageContents.Add(page);
            if (save)
                _context.SaveChanges();

            return page;
        }

        public PageContent GetPageContentBy(string pageName)
        {
            return _context.PageContents
                .Include(p => p.Contents)
                .ThenInclude(c => c.ContentName)
                .Include(p => p.Images)
                .AsSplitQuery()
                .SingleOrDefault(p => p.PageName == pageName);
        }

        public List<PageContent> GetPageContents(params string[] names)
        {
            IQueryable<PageContent> pages = _context.PageContents
                .Include(p => p.Contents)
                .ThenInclude(con => con.ContentName)
                .Include(p => p.Images)
                .AsSplitQuery();

            if(names.Count() > 0)
            {
                pages = pages.Where(p => names.Contains(p.PageName));
            }

            return pages.ToList();
        }

        public int GetPageIdBy(string PageName)
        {
            return _context.PageContents
                .SingleOrDefault(p => p.PageName == PageName)
                .PageId;
        }

        public List<Tuple<string, string, int>> GetPageNames(string filterName = "")
        {
            IQueryable<PageContent> pages = _context.PageContents;

            if (filterName != "" || filterName != null)
            {
                pages = pages.Where(p => 
                EF.Functions.Like(p.DisplayName, $"%{filterName}%") || 
                EF.Functions.Like(p.PageName, $"%{filterName}%"));
            }

            return pages
                .Select(p => 
                new Tuple<string, string, int>(p.PageName, p.DisplayName, p.PageId))
                .ToList();
        }

        public void UpdateContent(string contentName, string newContent)
        {
            var content = _context.ContentNames
                .Include(c => c.Content)
                .SingleOrDefault(c => c.Name == contentName);

            if (content == null)
                return;

            content.Content.ContentHtml = newContent;
            _context.SaveChanges();
        }

        public void UpdateImageContent(string imgKey, IFormFile image)
        {
            var img = _context.ImageContents
                .SingleOrDefault(i => i.ImageKey == imgKey);

            if (img == null)
                return;

            img.ImageName = UploadFile.ReplaceNew(image, img.ImageName, null, "wwwroot", "main", "img");

            _context.SaveChanges();
        }

        public void UpdatePageContents(string pageName, List<ContentDto> contents, List<ImageContentDto> images, bool save = true)
        {
            var pageContent = GetPageContentBy(pageName);
            //ToDo
            foreach (var content in pageContent.Contents)
            {
                var conDto = contents.SingleOrDefault(c => content.ContentName.Name == c.ContentName);

                if (conDto == null)
                    continue;

                content.ContentHtml = conDto.Content;
            }

            foreach (var image in pageContent.Images)
            {
                var imgFile = images.SingleOrDefault(i => i.ImgKey == image.ImageKey).ImageFile;

                if (imgFile == null)
                    continue;

                image.ImageName = UploadFile.ReplaceNew(imgFile,
                    image.ImageName, null,
                    "wwwroot","main","img");

                //ImageResize.Resize(image.ImageName,650,390,
                //    "wwwroot", "main", "img");
            }

            _context.PageContents.Update(pageContent);

            if (save)
                _context.SaveChanges();
        }
    }
}
