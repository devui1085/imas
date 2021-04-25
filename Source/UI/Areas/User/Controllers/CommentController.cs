using System.Collections.Generic;
using System.Web.Mvc;
using IMAS.Common.Data;
using IMAS.Facade.Core;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.UI.Infrastructure.SignalR;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class CommentController : BaseController
    {
        public ArticleService ContentManagement { get; set; }
        public CommentService CommentManagement { get; set; }

        public CommentController()
        {
            ContentManagement = new ArticleService();
            CommentManagement = new CommentService(SignalRPushNotificationProvider.Instance);
        }

        public ActionResult Index(int? contentId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadComments(DataSourceRequest request)
        {
            return Json(CommentManagement.ReadCommentsForViewByOwner(request, User), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> ids)
        {
            CommentManagement.DeleteComments(ids, User);
            return Json(true);
        }

    }
}