using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using IMAS.PresentationModel.Model;

namespace IMAS.Bussines.Core
{
    public class MessageBiz : BizBase<Message>
    {
        public MessageBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public IQueryable<Message> ReadUserMessages(int userId, int count)
        {
            return Read(m => m.ReceiverId == userId)
                .OrderByDescending(m => m.CreateDate)
                .Take(count);
        }

        public Message Add(int senderId, int receiverId, string text)
        {
            return Add(new Message() {
                CreateDate = DateTime.Now,
                SenderId = senderId,
                ReceiverId = receiverId,
                Text = text
            });
        }
    }
}