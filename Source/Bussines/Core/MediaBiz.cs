using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;
using IMAS.Common.Enum;

namespace IMAS.Bussines.Core
{
    public class MediaBiz : BizBase<Media>
    {
        public MediaBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public Media AddMedia(string fileName, int size, MediaType type, int userId)
        {
            return Add(new Media() {
                FileName = fileName,
                Size = size,
                Type = type,
                UserId = userId,
                CreateDate  = DateTime.Now,
            });
        }

        public void Remove(int id, int userId)
        {
            Remove(ReadSingle(m => m.Id == id && m.UserId == userId));
        }
    }
}