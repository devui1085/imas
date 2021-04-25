using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.UI.ViewModels;
using IMAS.UI.Controllers;

namespace IMAS.UI.Controllers
{
    public class AdvertismentController : BaseController
    {
        AdvertismentService AdvertismentService { get; }
        UserProfileService UserProfileService { get; }
        public AdvertismentController()
        {
            AdvertismentService = new AdvertismentService();
            UserProfileService = new UserProfileService();
        }

        // GET: Advertisment
        [Route("advertisment/{id:int}", Name = "ViewAdvertisment")]
        public ActionResult Index(int id)
        {
            var advertisment = AdvertismentService.GetAdvertisment(id);
            AdvertismentService.IncreaseAdvertismentVisitCount(id);
            var pictures = AdvertismentService.GetPictures(id);
            var contactInfo = UserProfileService.GetContactInfo(advertisment.UserId, User);
            int totalVisits = AdvertismentService.GetAdvertismentTotalVisits(id);
       
            return View(new AdvertismentViewModel { Advertisment = advertisment, Pictures = pictures, ContactInfo = contactInfo, TotalVisits = totalVisits });
        }

        [HttpGet]
        public ActionResult GetAdvertismentVisitChartData(int advertismentId)
        {
            return Json(AdvertismentService.GetAdvertismentVisitChartData(advertismentId), JsonRequestBehavior.AllowGet);
        }
    }
}