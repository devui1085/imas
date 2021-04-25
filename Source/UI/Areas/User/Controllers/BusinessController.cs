using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.UI.Areas.User.ViewModels.Business;
using IMAS.UI.Areas.User.ViewModels.Profile;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.Validation.Attributes;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class BusinessController : BaseController
    {
        public UserProfileService UserProfileService { get; set; }
        public UserBusinessService UserBusinessService { get; set; }

        public BusinessController()
        {
            UserProfileService = new UserProfileService();
            UserBusinessService = new UserBusinessService();
        }

        public ActionResult Index()
        {
            var viewModel = new BusinessViewModel() {
                ProfileStatisticsAndSocialLinks = UserProfileService.ReadProfileStatisticsAndSocialLinks(User.UserId),
                BusinessIntroduce = UserBusinessService.ReadUserBusinesIntroduce(User.UserId),
            };
            return View(viewModel);
        }

        #region Business Introduce
        [HttpPost]
        [ValidateModel]
        public ActionResult UpdateBusinessIntroduce(BusinessViewModel viewModel)
        {
            UserBusinessService.UpdateBusinesIntroduce(User, viewModel.BusinessIntroduce);
            return Json("");
        }
        #endregion
    }
}