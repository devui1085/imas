using System;
using System.ComponentModel.DataAnnotations;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.UI.ViewModels.PasswordReset
{
    public class SetNewPasswordViewModel
    {
        public string Email { get; set; }

        public Guid PasswordResetToken { get; set; }
        public int UserId { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(5, 25)]
        public string Password  { get; set; }

        [RequiredField]
        [LocalizedName]
        [Compare("Password", ErrorMessageResourceName = "PasswordAndPasswordConfirmMismatch", ErrorMessageResourceType = (typeof(Localization.Resources)))]
        public string PasswordConfirm  { get; set; }

        public bool IsPasswordResetTokenValid { get; set; }
    }
}