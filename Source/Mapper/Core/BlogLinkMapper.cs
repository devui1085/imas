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
    public static class BlogLinkMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<BlogLink, BlogLinkPM>();
            profile.CreateMap<BlogLinkPM, BlogLink>();
        }

        public static BlogLink GetLink(this BlogLinkPM linkPM)
        {
            return AutoMapper.Mapper.Map<BlogLinkPM, BlogLink>(linkPM);
        }

        public static BlogLinkPM GetLinkPM(this BlogLink link)
        {
            return AutoMapper.Mapper.Map<BlogLink, BlogLinkPM>(link);
        }
    }
}
