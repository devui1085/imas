using IMAS.Common.Enum;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.Common.Globalization;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class NotificationMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Notification, NotificationPM>()
                  .ForMember(pm => pm.CreateDateString, opt => opt.Ignore());
        }

        public static NotificationPM GetNotificationPM(this Notification notification)
        {
            return AutoMapper.Mapper.Map<Notification, NotificationPM>(notification);
        }
    }
}
