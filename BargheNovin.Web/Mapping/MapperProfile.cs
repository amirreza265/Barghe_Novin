using AutoMapper;
using BargheNovin.Core.DTOs.Content;
using BargheNovin.DataLayer.Entities.PageContent;
using BargheNovin.Web.Areas.Admin.Models.PagiesContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BargheNovin.Web.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PageContent, ServicesPageContentViewModel>()
                .ForMember(des => des.PageName, opt => opt.MapFrom(src => src.PageName))
                .ForMember(des => des.ServicesDescription, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "ServicesDescription").ContentHtml))
                .ForMember(des => des.ImageName, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault().ImageName))
                .ForMember(des => des.ImageKey, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault().ImageKey))
                .ForMember(des => des.STextTitle1, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle1").ContentHtml))

                .ForMember(des => des.STextTitle2, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle2").ContentHtml))

                .ForMember(des => des.STextTitle3, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle3").ContentHtml))

                .ForMember(des => des.STextTitle4, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle4").ContentHtml))

                .ForMember(des => des.SText1, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText1").ContentHtml))

                .ForMember(des => des.SText2, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText2").ContentHtml))

                .ForMember(des => des.SText3, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText3").ContentHtml))

                .ForMember(des => des.SText4, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText4").ContentHtml));


            CreateMap<PageContent, PageViewModel>()
                .ForMember(des => des.ImageContents, opt => opt.MapFrom(src => src.Images));

            CreateMap<PageContent, InputPageContentViewModel>();

            CreateMap<Content, ContentDto>()
                .ForMember(cond => cond.Content, option => option.MapFrom(con => con.ContentHtml))
                .ForMember(cond => cond.ContentName, option => option.MapFrom(con => con.ContentName.Name))
                .ReverseMap();

            CreateMap<ImageContent, ShowImageViewModel>();
            CreateMap<ImageContent, ImageContentDto>()
                .ForMember(des => des.ImgKey, opt => opt.MapFrom(src => src.ImageKey))
                .ReverseMap();
        }
    }
}
