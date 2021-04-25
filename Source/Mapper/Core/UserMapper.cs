using System.Linq;
using IMAS.Common.Enum;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.Security.ExtensionMethod;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class UserMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<UserRegistrationPM, User>();

            // UserInfoPm
            profile.CreateMap<User, UserInfoPm>()
                .ForMember(pm => pm.FullName, opt => opt.Ignore())
                .ForMember(pm => pm.IsApproved, opt => opt.MapFrom(model => model.Membership.IsApproved))
                .ForMember(pm => pm.IsLockedOut, opt => opt.MapFrom(model => model.Membership.IsLockedOut))
                .ForMember(pm => pm.CreateDate, opt => opt.MapFrom(model => model.Membership.CreateDate))
                .ForMember(pm => pm.LastLoginDate, opt => opt.MapFrom(model => model.Membership.LastLoginDate));

            profile.CreateMap<User, AdminDashboardNewUserPm>()
                .ForMember(pm => pm.FullName, opt => opt.Ignore())
                .ForMember(pm => pm.ImageUrl, opt => opt.Ignore());


            // UserInfoPm
            profile.CreateMap<User, ProfileGeneralSettingsPM>();
        }

        public static User GetUser(this UserRegistrationPM userRegistrationPM)
        {
            return AutoMapper.Mapper.Map<UserRegistrationPM, User>(userRegistrationPM);
        }

        public static ProfileGeneralSettingsPM GetProfileGeneralSettingsPM(this User user)
        {
            var pm = AutoMapper.Mapper.Map<User, ProfileGeneralSettingsPM>(user);
            pm.AboutMe = user.Profiles.SingleOrDefault(kv => kv.Type == ProfileKeyValueType.AboutMe)?.Value;
            pm.MobileNumber = user.Profiles.SingleOrDefault(kv => kv.Type == ProfileKeyValueType.MobileNumber)?.Value;
            pm.Tel = user.Profiles.SingleOrDefault(kv => kv.Type == ProfileKeyValueType.Tel)?.Value;
            pm.WebSiteUrl = user.Profiles.SingleOrDefault(kv => kv.Type == ProfileKeyValueType.WebSiteUrl)?.Value;
            return pm;
        }
    }
}
