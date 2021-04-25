using Common.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model;
using IMAS.Security.Identity;
using IMAS.UI.Areas.User.ViewModels.Article;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class ArticleController : BaseController
    {
        public ArticleService ArticleService { get; set; }
        public ContentService ContentService { get; set; }

        public ArticleController()
        {
            ArticleService = new ArticleService();
            ContentService = new ContentService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadUserContents(DataSourceRequest request)
        {
            return Json(ArticleService.ReadUserArticles(User, request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            //Response.AddHeader("Access-Control-Allow-Origin", "http://storage.tahacnc.com");
            var viewModel = new EditArticleViewModel() {
                Content = new ContentRegistrationPM() {
                    Published = false,
                },
                Tags = new List<string>()
            };
            return View("Edit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ContentRegistrationPM content;
            List<string> tags = null;
            if (!id.HasValue) return Add();

            ArticleService.ReadArticleForEdit(User, id.Value, out content, out tags);
            var viewModel = new EditArticleViewModel() { Content = content, Tags = tags };
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Save(EditArticleViewModel viewModel)
        {
            if (viewModel.Content.Id.HasValue) {
                ArticleService.EditArticle(viewModel.Content, viewModel.Tags);
            }
            else {
                viewModel.Content.AuthorId = User.UserId;
                ArticleService.AddArticle(viewModel.Content, viewModel.Tags);
            }

            return Json(new ProcessResult(new { ContentId = viewModel.Content.Id }));
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> ids)
        {
            ContentService.ChangeContentsState(ids, ContentState.Trashed, User);
            return Json(true);
        }
    }
}