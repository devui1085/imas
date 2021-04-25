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
using Common.Exception;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.ModelContainer.Blog;
using IMAS.PresentationModel.Model.Archive;

namespace IMAS.Facade.Core
{
    public class PublicationService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        BlogBiz BlogBiz { get; set; }
        PublicationBiz PublicationBiz { get; set; }
        ContentBiz ContentBiz { get; set; }

        public PublicationService()
        {
            UnitOfWork = new CoreUnitOfWork();
            BlogBiz = new BlogBiz(UnitOfWork);
            PublicationBiz = new PublicationBiz(UnitOfWork);
            ContentBiz = new ContentBiz(UnitOfWork);
        }

        public object ReadPublicationHomePageData(string publicationName)
        {
            var publication = PublicationBiz.Include(p => p.Creator).SingleOrDefault(p => p.Name == publicationName);
            if (publication == null)
                throw new PageNotFoundException();
            if (publication is Blog)
                return ReadBlogHomePageData((Blog)publication);
            else
                return ReadChannelHomePageData((Channel)publication);
        }

        private BlogHomePageModelContainer ReadBlogHomePageData(Blog blog)
        {
            return new BlogHomePageModelContainer() {
                BlogInfo = blog.GetBlogInfo(),
                ArchiveItems = PublicationBiz.ReadPublicationArchivedItemsCalendar(blog.Id, ContentType.BlogPost)
                     .Select(item => new ContentArchiveItemPM(item.Item1, item.Item2)),
                Links = BlogBiz.ReadBlogLinks(blog.Id)
                     .MapTo<BlogLinkPM>()
                     .ToList(),
                LatestPosts = BlogBiz.ReadUserPublishedPostsForViewByVisitor(blog.CreatorId)
                    .Take(100)
                    .MapTo<ContentInfoWithTextPM>()
                    .ToList()
            };
        }

        private object ReadChannelHomePageData(Channel hannel)
        {
            throw new NotImplementedException();
        }
    }
}
