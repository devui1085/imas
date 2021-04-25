using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.PresentationModel.Model;
using DomainModel = IMAS.Model.Domain.Core;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class ProfileMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<DomainModel.Profile, ProfileForViewByVisitorPM>();
            profile.CreateMap<ProfileForViewByVisitorPM, DomainModel.Profile>();


        }

        public static DomainModel.Profile GetProfile(this ProfileForViewByVisitorPM ProfilePresentationModel)
        {
            return AutoMapper.Mapper.Map<ProfileForViewByVisitorPM, DomainModel.Profile>(ProfilePresentationModel);
        }

        public static ProfileForViewByVisitorPM GetPresentationModel(this DomainModel.Profile Profile)
        {
            return AutoMapper.Mapper.Map<DomainModel.Profile, ProfileForViewByVisitorPM>(Profile);
        }
    }
}
