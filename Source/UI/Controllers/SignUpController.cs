using Common.Exception;
using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.Localization.ExtensionMethod;
using IMAS.UI.ViewModels.SignUp;
using IMAS.Validation.Attributes;

namespace IMAS.UI.Controllers
{
    public class SignUpController : Controller
    {
        public UserRegistrationService UserRegistrationService { get; set; }
        public SignUpController()
        {
            UserRegistrationService = new UserRegistrationService();
        }

        [Route("signup")]
        public ActionResult Index()
        {
            return View(new SignUpViewModel() { });
        }

        [Route("signup")]
        [HttpPost]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignUpViewModel viewModel)
        {
            try {
                UserRegistrationService.RegisterUser(viewModel.User, false);
            }
            catch (BusinessException exp) {
                viewModel.ErrorMessage = exp.Message;
                viewModel.User.Password = viewModel.User.PasswordConfirm = "";
                return View("index", viewModel);
            }
            return RedirectToAction("ActivateYourAccount");
        }

        [HttpGet]
        public ActionResult ActivateYourAccount()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ActivateAccount(AccountActivationViewModel viewModel)
        {
            try {
                UserRegistrationService.ActivateAccount(viewModel.U, viewModel.VC);
            }
            catch (BusinessException exp) {
                viewModel.ErrorMessage = exp.Message;
            }
            return View("AccountActivationResult", viewModel);
        }

        [HttpGet]
        public ActionResult ResendActivationCode()
        {
            var viewModel = new ResendActivationCodeViewModel() {
                ShowSuccessMessage = false
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public ActionResult ResendActivationCode(ResendActivationCodeViewModel viewModel)
        {
            UserRegistrationService.ResendActivationEmail(viewModel.Email);
            viewModel.ShowSuccessMessage = true;
            viewModel.Email = "";
            return View(viewModel);
        }
    }
}