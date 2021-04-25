using IMAS.Common.Enum;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.Common.Globalization;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class MessageMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Message, MessagePM>()
                  .ForMember(pm => pm.SenderFullName, opt => opt.Ignore())
                  .ForMember(pm => pm.ReceiverFullName, opt => opt.Ignore())
                  .ForMember(pm => pm.CreateDateString, opt => opt.Ignore());
            profile.CreateMap<MessagePM, Message>();
        }

        public static Message GetMessage(this MessagePM messagePM)
        {
            return AutoMapper.Mapper.Map<MessagePM, Message>(messagePM);
        }

        public static MessagePM GetMessagePM(this Message message)
        {
            return AutoMapper.Mapper.Map<Message, MessagePM>(message);
        }
    }
}
