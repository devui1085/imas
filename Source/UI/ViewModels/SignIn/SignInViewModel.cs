using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.UI.ViewModels.SignIn
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {
            RememberMe = true;
        }

        [LocalizedName]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string Email { get; set; }
        [RequiredField]
        [LocalizedName]
        [RegularExpression(@"^09\d{9}",ErrorMessageResourceName = "InvalidCellphone", ErrorMessageResourceType = typeof(IMAS.Localization.Resources))]
        public string Cellphone { get; set; }

        [RequiredField]
        [LocalizedName]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public string ErrorMessage { get; set; }
    }
}