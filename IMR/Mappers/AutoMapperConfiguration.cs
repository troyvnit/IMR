using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.Models;
using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

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
                    .ForMember(a => a.ContentVi, o => o.MapFrom(x => x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi) != null ? x.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).Content : string.Empty))
                    .ForMember(a => a.RelatedArticleIds, o => o.ResolveUsing(x =>
                    {
                        var relatedArticles = x.RelatedArticles ?? new List<Article>();
                        return JsonConvert.SerializeObject(x.RelatedArticles.Select(ra => new { ra.ArticleId, ra.ArticleDetails.FirstOrDefault(ad => ad.Language == Language.En).Title }));
                    }));
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
            }
        }
    }
}