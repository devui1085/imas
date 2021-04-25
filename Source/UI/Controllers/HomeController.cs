using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.UI.ViewModels.Home;

namespace IMAS.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public AppStatisticsService AppStatistics { get; set; }
        public AdvertismentService AdvertismentService { get; set; }
        public HomeController()
        {
            AppStatistics = new AppStatisticsService();
            AdvertismentService = new AdvertismentService();
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel { LatestAdvertisments = AdvertismentService.GetLatestAdvertisments(0,12) };
            return View(homeViewModel);
        }

        [Route("about")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("privacy")]
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("terms", Order = 1)]
        public ActionResult TermsOfUse()
        {
            return View();
        }

        [Route("faq", Order = 1)]
        public ActionResult FAQ()
        {
            return View();
        }

        [Route("article")]
        public ActionResult SendArticle()
        {
            return View();
        }

        [Route("makeblog")]
        public ActionResult MakeBlog()
        {
            return View();
        }

        //[Route("search")]
        //public ActionResult Search()
        //{
        //    return View();
        //}

        [Route("introduction")]
        public ActionResult Introduction()
        {
            return View();
        }
        //[Route("Test")]
        //public ActionResult Test()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult GetAdavertisment(int startIndex, int offset)
        {
            var LatestAdvertisments = AdvertismentService.GetLatestAdvertisments(startIndex, offset);
            return Json(new
            {
                statusCode = 200,
                status = "success",
                advertisments = LatestAdvertisments,
            }, JsonRequestBehavior.AllowGet);
        }

    }
}