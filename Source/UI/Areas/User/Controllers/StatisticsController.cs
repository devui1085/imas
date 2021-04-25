using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMAS.Common.Data;
using IMAS.Common.DataProvider;
using IMAS.Common.Enum;
using IMAS.Facade.Core;
using IMAS.UI.Areas.User.ViewModels.AdminDashboard;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.Common.Globalization;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class StatisticsController : BaseController
    {
        private ArticleService ContentService { get; }
        private UserService UserService { get; }
        private AppStatisticsService AppStatisticsService { get; }

        public StatisticsController()
        {
            ContentService = new ArticleService();
            UserService = new UserService();
            AppStatisticsService = new AppStatisticsService();
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetAuthorTotalArticlesVisitsChartData()
        {
            var result = AppStatisticsService.GetAuthorTotalArticlesVisitsChartData(User).ToList();
            return GetChartData(result);
        }

        [HttpGet]
        public ActionResult GetUserProfileVisitsChartData()
        {
            var result = AppStatisticsService.GetAuthorTotalVisitsChartData(User).ToList();
            return GetChartData(result);
        }
        //[HttpGet]
        //public ActionResult GetAuthorTotalBlogPostsChartData()
        //{
        //    var result = AppStatisticsService.GetAuthorTotalBlogPostsChartData(User).ToList();
        //    return GetChartData(result);
        //}

        private ActionResult GetChartData(List<ChartData> result)
        {
            ChartDataHelper.FillBlankDays(result);
            var chartData = result.Select(cd => new { Date = cd.Date.ToNumericPersianDateString(), Visits = cd.Value });
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }
    }
}