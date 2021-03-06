using System.Linq;
using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.SetupBlog;
using IMAS.UI.Areas.User.ViewModels.SetupBlog;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.Validation.Attributes;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class SetupBlogController : BaseController
    {
        public SetupBlogService SetupBlogService { get; set; }

        public SetupBlogController()
        {
            SetupBlogService = new SetupBlogService();
        }

        public ActionResult Index()
        {
            if (User.HasBlog)
                return Redirect("/user/blog");
            var viewModel = new SetupBlogViewModel() {
                Blog = new BlogGeneralSettingsPM(),
            };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [ValidateModel]
        [HttpPost]
        public ActionResult Create(SetupBlogViewModel viewModel)
        {
            var blogId = SetupBlogService.CreateBlog(User, viewModel.Blog);
            return Json("");
        }

        [HttpGet]
        public ActionResult Created()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var viewModel = new EditBlogViewModel() {
                Blog = SetupBlogService.ReadBlogGeneralSettings(User.Blogs.First().Id)
            };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [ValidateModel]
        [HttpPost]
        public ActionResult Edit(EditBlogViewModel viewModel)
        {
            SetupBlogService.UpdateBlogGeneralSettings(User.Blogs.First().Id, viewModel.Blog);
            return Json("");
        }

    }
}