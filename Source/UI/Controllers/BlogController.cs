using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMAS.Common.Globalization;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.ModelContainer;
using IMAS.PresentationModel.ModelContainer.Blog;
using IMAS.UI.Infrastructure.SignalR;
using IMAS.UI.ViewModels.Blog;

namespace IMAS.UI.Controllers
{
    public class BlogController : BaseController
    {
        public PublicationService PublicationService { get; set; }
        public BlogService BlogService { get; set; }
        public CommentService CommentService { get; set; }

        public BlogController()
        {
            PublicationService = new PublicationService();
            BlogService = new BlogService(SignalRPushNotificationProvider.Instance);
            CommentService = new CommentService(SignalRPushNotificationProvider.Instance);
        }

        [Route("{publicationName:regex(^[a-zA-Z]{4,20}$)}/post/{postId}/{flag?}", Order = 10)]
        public ActionResult Post(string publicationName, int postId, string flag)
        {
            var previewMode = flag == "preview";
            ViewBlogPostModelContainer container;

            if (previewMode)
                container = BlogService.ReadPostForPreview(publicationName, postId);
            else
                container = BlogService.ReadPostForViewByVisitor(publicationName, postId);

            return View(new BlogPostViewModel(container, previewMode));
        }

        [Route("{publicationName:regex(^[a-zA-Z]{4,20}$)}/archive/{year:range(1397,1500)?}/{month:range(1,12)?}", Order = 10)]
        public ActionResult Archive(string publicationName, int? year, int? month)
        {
            return View(new BlogArchiveViewModel(BlogService.ReadArchiveForViewByVisitor(publicationName, year, month)));
        }

        [HttpPost]
        public ActionResult AddComment(CommentRegistrationPM comment)
        {
            CommentService.AddComment(comment, User);
            return Json(new { Id = comment.Id, CreateDate = comment.CreateDate.Value.ToPersianDate("g") });
        }
    }
}