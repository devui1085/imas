using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class MediaMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Media, MediaPM>();
            profile.CreateMap<MediaPM, Media>();
        }

        public static Media GetMedia(this MediaPM mediaPM)
        {
            return AutoMapper.Mapper.Map<MediaPM, Media>(mediaPM);
        }

        public static MediaPM  GetPresentationModel(this Media media)
        {
            return AutoMapper.Mapper.Map<Media, MediaPM>(media);
        }
    }
}
