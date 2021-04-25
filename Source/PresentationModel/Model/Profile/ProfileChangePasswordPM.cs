using System;
using System.ComponentModel.DataAnnotations;
using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model
{
    public class ProfileChangePasswordPM
    {
        [RequiredField]
        [LocalizedName]
        [StringLengthRange(5, 25)]
        public string CurrentPassword { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(5, 25)]
        public string Password { get; set; }

        [RequiredField]
        [LocalizedName]
        [Compare("Password", ErrorMessageResourceName = "PasswordAndPasswordConfirmMismatch", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string PasswordConfirm { get; set; }

    }
}
