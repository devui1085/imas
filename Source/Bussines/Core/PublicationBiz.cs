using System;
using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using IMAS.Common.Enum;
using System.Linq;
using System.Collections.Generic;
using IMAS.Common.ExtensionMethod;
using IMAS.Mapper.Core;
using System.Data.Entity;
using Common.Exception;
using IMAS.Localization.ExtensionMethod;
using IMAS.PresentationModel.Model.Archive;

namespace IMAS.Bussines.Core
{
    public class PublicationBiz : BizBase<Publication>
    {
        public PublicationBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public IEnumerable<Tuple<int, int>> ReadPublicationArchivedItemsCalendar(int publicationId, ContentType contentType)
        {
            return UnitOfWork.ContentRepository.Read(c =>
                        c.PublicationId == publicationId &&
                        c.Type == contentType &&
                        c.State == ContentState.Published)
                 .OrderBy(c => c.CreateDate)
                 .GroupBy(content => new { content.PersianCreateDateYear, content.PersianCreateDateMonth })
                 .Select(group => new { group.Key.PersianCreateDateYear, group.Key.PersianCreateDateMonth })
                 .ToList()
                 .Select(x => new Tuple<int, int>(x.PersianCreateDateYear, x.PersianCreateDateMonth));
        }
    }
}