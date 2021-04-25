using IMAS.Common.Enum;

namespace IMAS.Common.PushNotification
{
    public interface IPushNotificationProvider
    {
        void Send(int userId, PushNotificationType pushNotificationType, object data);
    }
}