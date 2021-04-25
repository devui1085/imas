using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMAS.Bussines.Core;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.Common.PushNotification;
using IMAS.Mapper.Core;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;

namespace IMAS.Facade.Core
{
    public class MessageService
    {
        IPushNotificationProvider PushNotification { get; set; }
        CoreUnitOfWork UnitOfWork { get; set; }
        MessageBiz MessageBiz { get; set; }
        NotificationBiz NotificationBiz { get; set; }

        public MessageService(IPushNotificationProvider pushNotificationProvider)
        {
            PushNotification = pushNotificationProvider;
            UnitOfWork = new CoreUnitOfWork();
            MessageBiz = new MessageBiz(UnitOfWork);
            NotificationBiz = new NotificationBiz(UnitOfWork);
        }

        public void CreateMessage(int senderId, int receiverId, string text)
        {
            var message = MessageBiz.Add(senderId, receiverId, text);
            var notification = NotificationBiz.Add(NotificationType.WriteMessage, senderId, null, receiverId);
            UnitOfWork.SaveChanges();

            // Send notification
            PushNotification.Send(receiverId, PushNotificationType.NewNotification, NotificationBiz.ProcessNotification(notification).GetNotificationPM());
        }

        public DataSourceResult ReadReceivedMessages(DataSourceRequest request, UserIdentity user)
        {
            return MessageBiz
                .Read(message => message.ReceiverId == user.UserId, noTracking: true)
                .OrderByDescending(message => message.CreateDate)
                .Include(message => message.Sender)
                .MapTo<MessagePM>()
                .ToDataSourceResult(request);
        }

        public DataSourceResult ReadSentMessages(DataSourceRequest request, UserIdentity user)
        {
            return MessageBiz
                .Read(message => message.SenderId == user.UserId, noTracking: true)
                .OrderByDescending(message => message.CreateDate)
                .Include(message => message.Receiver)
                .MapTo<MessagePM>()
                .ToDataSourceResult(request);
        }

        public void DeleteMessages(IEnumerable<int> ids, UserIdentity user)
        {
            //TODO: put here a security check
            var messages = ids.Select(id => new Message() { Id = id });
            messages.ForEach(message => MessageBiz.Remove(message));
            UnitOfWork.SaveChanges();
        }
    }
}
