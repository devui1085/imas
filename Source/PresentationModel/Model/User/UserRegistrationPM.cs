using System.ComponentModel.DataAnnotations;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model
{
    public class UserRegistrationPM
    {
        [LocalizedName]
        [StringLengthRange(2, 25)]
        public string FirstName { get; set; }

        [LocalizedName]
        [StringLengthRange(2, 25)]
        public string LastName { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(5,25)]
        public string Password { get; set; }

        [RequiredField]
        [LocalizedName]
        [Compare("Password", ErrorMessageResourceName = "PasswordAndPasswordConfirmMismatch", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string PasswordConfirm { get; set; }

        [LocalizedName]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType =(typeof(Localization.Resources)))]
        public string Email { get; set; }
        [RequiredField]
        [LocalizedName]
        [EmailAddress(ErrorMessageResourceName = "InvalidCellphone", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string Cellphone { get; set; }
    }
}
