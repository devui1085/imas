using IMAS.Bussines.Core;
using IMAS.Security.Helper;
using System.Linq;
using System.Data.Entity;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.PresentationModel.Model.Content;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using System;
using System.Collections;
using IMAS.PresentationModel.Model;
using System.Collections.Generic;
using IMAS.Mapper.Core;
using Common.Exception;
using IMAS.Localization.ExtensionMethod;

namespace IMAS.Facade.Core
{
    public class NotificationService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        NotificationBiz NotificationBiz { get; set; }
        UserBiz UserBiz { get; set; }
        ContentBiz ContentBiz { get; set; }

        public NotificationService()
        {
            UnitOfWork = new CoreUnitOfWork();
            NotificationBiz = new NotificationBiz(UnitOfWork);
            UserBiz = new UserBiz(UnitOfWork);
            ContentBiz = new ContentBiz(UnitOfWork);
        }

        public void SetNotificationAsRead(UserIdentity user, int notificationId)
        {
            var notification = NotificationBiz.ReadSingle(n => n.Id == notificationId);
            if (notification.ReceiverId != user.UserId)
                throw new BusinessException();
            notification.IsRead = true;
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<NotificationPM> ReadUserNotifications(int userId, int maxCount)
        {
            return NotificationBiz.ReadUserNotifications(userId, maxCount)
                .ToList()
                .Select(notification => NotificationBiz.ProcessNotification(notification).GetNotificationPM());
        }
    }
}
