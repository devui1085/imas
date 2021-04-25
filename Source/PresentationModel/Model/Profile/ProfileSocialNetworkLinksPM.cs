using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IMAS.Common.Enum;
using IMAS.Localization;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model
{
    public class ProfileSocialNetworkLinksPM
    {
        [LocalizedName]
        [Url(ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(Resources))]
        public string FacebookUrl { get; set; }

        [LocalizedName]
        [Url(ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(Resources))]
        public string LinkedInUrl { get; set; }

        [LocalizedName]
        [Url(ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(Resources))]
        public string TwitterUrl { get; set; }
    }
}
