using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.Models;
using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using IMR.ViewModels;
using System.Threading;

namespace IMR.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

        public class ViewModelToDomainMappingProfile : Profile
        {
            public override string ProfileName
            {
                get { return "ViewModelToDomainMappings"; }
            }

            protected override void Configure()
            {
                Mapper.CreateMap<ArticleCategoryBO, ArticleCategory>();
                Mapper.CreateMap<ArticleBO, Article>();
                Mapper.CreateMap<SettingBO, Setting>();
            }
        }

        public class DomainToViewModelMappingProfile : Profile
        {
            public override string ProfileName
            {
                get { return "DomainToViewModelMappings"; }
            }

            protected override void Configure()
            {
                Mapper.CreateMap<ArticleCategory, ArticleCategoryBO>()
                    .ForMember(a => a.CategoryIdEn, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.En).ArticleCategoryDetailId : 0))
                    .ForMember(a => a.CategoryIdDe, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.De).ArticleCategoryDetailId : 0))
                    .ForMember(a => a.CategoryIdVi, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.Vi).ArticleCategoryDetailId : 0))
                    .ForMember(a => a.NameEn, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.En).Name : ""))
                    .ForMember(a => a.NameDe, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.De).Name : ""))
                    .ForMember(a => a.NameVi, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => a.Language == Language.Vi).Name : ""));
                Mapper.CreateMap<Article, ArticleBO>()
                    .ForMember(a => a.IdEn, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En).ArticleDetailId : 0))
                    .ForMember(a => a.IdDe, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De).ArticleDetailId : 0))
                    .ForMember(a => a.IdVi, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).ArticleDetailId : 0))
                    .ForMember(a => a.TitleEn, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En).Title : string.Empty))
                    .ForMember(a => a.TitleDe, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De).Title : string.Empty))
                    .ForMember(a => a.TitleVi, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).Title : string.Empty))
                    .ForMember(a => a.DescriptionEn, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En).Description : string.Empty))
                    .ForMember(a => a.DescriptionDe, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De).Description : string.Empty))
                    .ForMember(a => a.DescriptionVi, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).Description : string.Empty))
                    .ForMember(a => a.ContentEn, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.En).Content : string.Empty))
                    .ForMember(a => a.ContentDe, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.De).Content : string.Empty))
                    .ForMember(a => a.ContentVi, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).Content : string.Empty));
                Mapper.CreateMap<Setting, SettingBO>()
                    .ForMember(a => a.IdEn, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.En).SettingDetailId : 0))
                    .ForMember(a => a.IdDe, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.De).SettingDetailId : 0))
                    .ForMember(a => a.IdVi, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi).SettingDetailId : 0))
                    .ForMember(a => a.NameEn, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.En).Name : string.Empty))
                    .ForMember(a => a.NameDe, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.De).Name : string.Empty))
                    .ForMember(a => a.NameVi, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi).Name : string.Empty))
                    .ForMember(a => a.DescriptionEn, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.En).Description : string.Empty))
                    .ForMember(a => a.DescriptionDe, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.De).Description : string.Empty))
                    .ForMember(a => a.DescriptionVi, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi).Description : string.Empty))
                    .ForMember(a => a.LinkEn, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.En) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.En).Link : string.Empty))
                    .ForMember(a => a.LinkDe, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.De) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.De).Link : string.Empty))
                    .ForMember(a => a.LinkVi, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.SettingDetails.FirstOrDefault(a => a.Language == Language.Vi).Link : string.Empty));
                Mapper.CreateMap<Article, ArticleVM>()
                    .ForMember(a => a.SeoTitle, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).SeoTitle : ""))
                    .ForMember(a => a.Title, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Title : ""))
                    .ForMember(a => a.Description, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Description : ""))
                    .ForMember(a => a.Content, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.ArticleDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Content : ""));
                Mapper.CreateMap<ArticleCategory, ArticleCategoryVM>()
                    .ForMember(a => a.Name, o => o.MapFrom(x => x.ArticleCategoryDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.ArticleCategoryDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Name : ""));
                Mapper.CreateMap<Setting, SettingVM>()
                    .ForMember(a => a.Name, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Name : ""))
                    .ForMember(a => a.Link, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Link : ""))
                    .ForMember(a => a.Description, o => o.MapFrom(x => x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())) != null ? x.SettingDetails.FirstOrDefault(a => Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(a.Language.ToString().ToLower())).Description : ""));
                Mapper.CreateMap<SettingDetail, SettingDetailVM>()
                    .ForMember(a => a.Avatar, o => o.MapFrom(x => x.Setting.Avatar));
            }
        }
    }
}