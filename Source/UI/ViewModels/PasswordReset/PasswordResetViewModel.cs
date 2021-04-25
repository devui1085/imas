using System;
using System.ComponentModel.DataAnnotations;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.UI.ViewModels.PasswordReset
{
    public class PasswordResetViewModel
    {
        [RequiredField]
        [LocalizedName]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string Email { get; set; }

        public bool ShowSuccessMessage { get; set; }
    }
}