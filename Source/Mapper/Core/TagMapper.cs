using AutoMapper.QueryableExtensions;
using System.Linq;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class TagMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Tag, TagPM>();
            profile.CreateMap<TagPM, Tag>();
        }

        public static Tag GetTag(this TagPM tagPresentationModel)
        {
            return AutoMapper.Mapper.Map<TagPM, Tag>(tagPresentationModel);
        }

        public static TagPM  GetPresentationModel(this Tag tag)
        {
            return AutoMapper.Mapper.Map<Tag, TagPM>(tag);
        }
    }
}
