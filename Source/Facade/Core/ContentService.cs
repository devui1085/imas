using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using IMAS.Bussines.Core;
using IMAS.Common.Data;
using IMAS.Common.DataProvider;
using IMAS.Common.ExtensionMethod;
using IMAS.Common.Globalization;
using IMAS.Common.Enum;
using IMAS.Mapper.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;

namespace IMAS.Facade.Core
{
    public class ContentService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        ContentBiz ContentBiz { get; set; }
        TagBiz TagBiz { get; set; }

        public ContentService()
        {
            UnitOfWork = new CoreUnitOfWork();
            ContentBiz = new ContentBiz(UnitOfWork);
            TagBiz = new TagBiz(UnitOfWork);
        }

        public DataSourceResult GetAllContents(DataSourceRequest request)
        {
            return ContentBiz.Read(content =>
                content.State != ContentState.Trashed, noTracking: true).Include(c => c.Author)
                .MapTo<ContentInfo1PM>()
                .ToDataSourceResult(request);
        }

        public void ChangeContentsState(IEnumerable<int> ids, ContentState state, UserIdentity userIdentity)
        {
            ContentBiz.Read(content =>
                    content.AuthorId == userIdentity.UserId &&
                    ids.Contains(content.Id))
                .ToList()
                .ForEach(content => content.State = state);
            UnitOfWork.SaveChanges();
        }

        public void ChangeContentsState(IEnumerable<int> ids, ContentState state)
        {
            ContentBiz.Read(content =>
                    ids.Contains(content.Id))
                .ToList()
                .ForEach(content => content.State = state);
            UnitOfWork.SaveChanges();
        }
    }
}
