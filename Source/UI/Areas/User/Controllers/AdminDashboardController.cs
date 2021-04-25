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
    [AuthorizeUser(Roles = "admin")]
    public class AdminDashboardController : BaseController
    {
        private ContentService ContentService { get; }
        private UserService UserService { get; }
        private AppStatisticsService AppStatisticsService { get; }
        private AdvertismentService AdvertismentService { get; }
        public AdminDashboardController()
        {
            ContentService = new ContentService();
            UserService = new UserService();
            AppStatisticsService = new AppStatisticsService();
            AdvertismentService = new AdvertismentService();
        }

        public ActionResult Index()
        {
            var container = AppStatisticsService.GetAdminDashboardStatistics();
            var viewModel = new AdminDashboardViewModel(container);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetAllContents(DataSourceRequest request)
        {
            return Json(ContentService.GetAllContents(request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllUsers(DataSourceRequest request)
        {
            return Json(UserService.GetAllUsers(request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Advertisments()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllAdvertisments(DataSourceRequest request)
        {
            return Json( AdvertismentService.GetAllAdvertisments(request,new AdvertismentFilter { Status = AdvertismentStatus.All }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PendingAdvertisments()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPendingAdvertisments(DataSourceRequest request)
        {
            return Json(AdvertismentService.GetAllAdvertisments(request, new AdvertismentFilter { Status = AdvertismentStatus.Pending }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSiteVisitChartData()
        {
            var result = AppStatisticsService.GetSiteTotalVisistsByDate().ToList();
            return GetChartData(result);
        }

        [HttpGet]
        public ActionResult GetUsersRegistrationStatisticChartData()
        {
            var result = AppStatisticsService.GetUsersRegistrationStatisticByDate().ToList();
            return GetChartData(result);
        }

        [HttpGet]
        public ActionResult GetAdvertismentStatisticChartData()
        {
            var result = AppStatisticsService.GetAdvertismentStatisticChartData().ToList();
            return GetChartData(result);
        }

        [HttpGet]
        public ActionResult GetBlogPostPublishStatisticChartData()
        {
            var result = AppStatisticsService.GetBlogPostPublishStatisticByDate().ToList();
            return GetChartData(result);
        }

        private ActionResult GetChartData(List<ChartData> result)
        {
            ChartDataHelper.FillBlankDays(result);
            var chartData = result.Select(cd => new {
                Date = cd.Date.ToPersianDate("MMDD"),
                Visits = cd.Value
            });
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BlockUsers(int[] ids)
        {
            UserService.BlockUsers(ids);
            return Json(new object());
        }

        public JsonResult UnblockUsers(int[] ids)
        {
            UserService.UnblockUsersById(ids);
            return Json(new object());
        }
        public JsonResult RemoveUsers(int[] ids)
        {
            UserService.RemoveUsersById(ids);
            return Json(new object());
        }
        public JsonResult RemoveAdvertisments(int[] ids)
        {
            AdvertismentService.RemoveAdvertisments(ids);
            return Json(new object());
        }

        public JsonResult ConfirmAdvertisments(int[] ids)
        {
            AdvertismentService.ChangeAdvertismentsStatus(ids, AdvertismentStatus.Published);
            return Json(new object());
        }

        public JsonResult UnconfirmAdvertisments(int[] ids)
        {
            AdvertismentService.ChangeAdvertismentsStatus(ids,AdvertismentStatus.Unconfirmed);
            return Json(new object());
        }
    }
}