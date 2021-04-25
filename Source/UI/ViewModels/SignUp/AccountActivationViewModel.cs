using System;
using System.ComponentModel.DataAnnotations;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.UI.ViewModels.SignUp
{
    public class AccountActivationViewModel
    {
        /// <summary>
        /// Verification Code
        /// </summary>
        public Guid VC { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int U { get; set; }
        public string ErrorMessage { get; set; }
    }
}