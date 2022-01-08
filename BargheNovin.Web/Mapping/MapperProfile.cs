using AutoMapper;
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
                .ForMember(des => des.Description, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "ServicesDescription").ContentHtml))
                .ForMember(des => des.ImageName, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault().ImageName))
                .ForMember(des => des.TextTitle1, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle1").ContentHtml))

                .ForMember(des => des.TextTitle2, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle2").ContentHtml))

                .ForMember(des => des.TextTitle3, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle3").ContentHtml))

                .ForMember(des => des.TextTitle4, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "STextTitle4").ContentHtml))

                .ForMember(des => des.Text1, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText1").ContentHtml))

                .ForMember(des => des.Text2, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText2").ContentHtml))

                .ForMember(des => des.Text3, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText3").ContentHtml))

                .ForMember(des => des.Text4, opt => opt.MapFrom(src =>
                    src.Contents.FirstOrDefault(content => content.ContentName.Name == "SText4").ContentHtml));
        }
    }
}
