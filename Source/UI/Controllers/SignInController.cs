using Common.Exception;
using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.Localization.ExtensionMethod;
using IMAS.Security.Identity;
using IMAS.UI.Infrastructure.Mvc;
using IMAS.UI.ViewModels.SignIn;

namespace IMAS.UI.Controllers
{
    public class SignInController : BaseController
    {
        public UserService UserManager { get; set; }
        public UserRegistrationService UserRegistrationService { get; }
        public SignInController()
        {
            UserManager = new UserService();
            UserRegistrationService = new UserRegistrationService();
        }

        [Route("signin")]
        public ActionResult Index()
        {
            if (SessionManager.GetUserIdentity() != null)
                return RedirectToAction("index", "dashboard", new { area = "user" });
            return View(new SignInViewModel() { });
        }

        [HttpPost]
        [Route("signin")]
        public ActionResult Index(SignInViewModel viewModel)
        {
            var userIdentity = new UserIdentity();
            try
            {
                if (!UserManager.ExistUser(viewModel.Cellphone))
                {
                    try
                    {
                        var newUser = new PresentationModel.Model.UserRegistrationPM { Cellphone = viewModel.Cellphone, Password = viewModel.Password };
                        UserRegistrationService.RegisterUser(newUser, false);
                    }
                    catch (BusinessException exp)
                    {
                        viewModel.ErrorMessage = exp.Message;
                        viewModel.Password = string.Empty;
                        return View("index", viewModel);
                    }
                }
                UserManager.SignIn(viewModel.Cellphone, viewModel.Password, userIdentity);
            }
            catch (BusinessException exp)
            {
                viewModel.ErrorMessage = exp.Message;
                viewModel.Password = "";
                return View(viewModel);
            }

            SessionManager.StoreUserIdentity(userIdentity);
            CookieManager.WriteAuthenticationCookie(userIdentity, viewModel.RememberMe);
            var controllerName = userIdentity.IsInRole("admin") ? "admindashboard" : "dashboard";
            return RedirectToAction("index", controllerName, new { area = "user" });
        }
    }
}