using System.Web.Mvc;
using IMAS.Common.Enum;
using IMAS.Facade.Core;
using IMAS.UI.Areas.User.ViewModels.Dashboard;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class DashboardController : BaseController
    {
        private AppStatisticsService AppStatisticsService { get; }

        public DashboardController()
        {
            AppStatisticsService = new AppStatisticsService();
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel(AppStatisticsService.GetUserDashboardData(User.UserId));
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetArticlesVisitChartData()
        {
            return Json(AppStatisticsService.GetContentVisitChartDataForUserDashboard(User.UserId, ContentType.Article), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUserAdvertismentsVisitChartData()
        {
            return Json(AppStatisticsService.GetUserAdvertismentsStatisticChartData(User), JsonRequestBehavior.AllowGet);
        }

  
        [HttpGet]
        public ActionResult GetPostsVisitChartData()
        {
            return Json(AppStatisticsService.GetContentVisitChartDataForUserDashboard(User.UserId, ContentType.BlogPost), JsonRequestBehavior.AllowGet);
        }

    }
}