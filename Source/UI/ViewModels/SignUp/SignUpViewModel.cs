using IMAS.PresentationModel.Model;
using IMAS.Validation.Attribute;

namespace IMAS.UI.ViewModels.SignUp
{
    public class SignUpViewModel
    {
        public UserRegistrationPM User { get; set; }

        [EnforceTrue("MsgYouShouldAcceptLicenceTerms")]
        public bool IAcceptLicenceTerms { get; set; }

        public string ErrorMessage { get; set; }
    }
}