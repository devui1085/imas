using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMAS.Common.Data;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model.Blog;
using IMAS.UI.Areas.User.ViewModels.BlogFriend;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.UI.Infrastructure.SignalR;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class BlogLinkController : BaseController
    {
        public BlogService BlogService { get; set; }
        public ContentService ContentService { get; set; }

        public BlogLinkController()
        {
            BlogService = new BlogService(SignalRPushNotificationProvider.Instance);
            ContentService = new ContentService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadFriends(DataSourceRequest request)
        {
            return Json(BlogService.ReadBlogLinks(User.Blogs.First().Id, request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(BlogLinkViewModel viewModel)
        {
            BlogService.AddBlogLink(User.Blogs.First().Id, viewModel.Link);
            return Json(new { Id = viewModel.Link.Id });
        }

        [HttpPost]
        public ActionResult Edit(BlogLinkPM blogFriend)
        {
            BlogService.EditBlogLink(User.Blogs.First().Id, blogFriend);
            return Json(true);
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> ids)
        {
            BlogService.DeleteBlogLinks(User.Blogs.First().Id, ids);
            return Json(true);
        }
    }
}