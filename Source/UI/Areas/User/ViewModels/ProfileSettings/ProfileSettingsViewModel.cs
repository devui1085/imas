using System;
using IMAS.Common.Enum;
using IMAS.PresentationModel.Model;

namespace IMAS.UI.Areas.User.ViewModels.Profile
{
    public class ProfileSettingsViewModel
    {
        public ProfileGeneralSettingsPM GeneralSettings { get; set; }
        public ProfileSocialNetworkLinksPM ProfileSocialNetworkUrls { get; set; }
        public ProfileChangePasswordPM ChangePasswordPM { get; set; }
        public ProfileStatisticsAndSocialLinksPM ProfileStatisticsAndSocialLinks { get; set; }
    }
}