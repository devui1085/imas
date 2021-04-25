using System.Collections.Generic;
using System.Linq;
using IMAS.Common.Enum;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.Model.SetupBlog;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class BlogMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<BlogGeneralSettingsPM, Blog>();
            profile.CreateMap<Blog, BlogGeneralSettingsPM>();

            profile.CreateMap<Blog, ShortBlogInfoPM>();
            profile.CreateMap<Blog, BlogInfoPM>()
                .ForMember(pm => pm.CreatorFullName, opt => opt.Ignore());

            profile.CreateMap<Blog, BlogInfoForGenerateLinkPM>();
        }

        public static Blog GetBlog(this BlogGeneralSettingsPM blogRegisterationPM)
        {
            return AutoMapper.Mapper.Map<BlogGeneralSettingsPM, Blog>(blogRegisterationPM);
        }

        public static BlogGeneralSettingsPM GetGeneralSettingsPM(this Blog blog)
        {
            return AutoMapper.Mapper.Map<Blog, BlogGeneralSettingsPM>(blog);
        }

        public static BlogInfoPM GetBlogInfo(this Blog blog)
        {
            return AutoMapper.Mapper.Map<Blog, BlogInfoPM>(blog);
        }

        public static ShortBlogInfoPM GetShortBlogInfo(this Blog blog)
        {
            return AutoMapper.Mapper.Map<Blog, ShortBlogInfoPM>(blog);
        }
        public static BlogInfoForGenerateLinkPM GetBlogInfoForGenerateLink(this Blog blog)
        {
            return AutoMapper.Mapper.Map<Blog, BlogInfoForGenerateLinkPM>(blog);
        }
    }
}
