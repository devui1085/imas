using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model;
using IMAS.UI.ViewModels.Article;
using IMAS.Common.Globalization;
using IMAS.UI.Infrastructure.StaticResource;
using IMAS.Common.Enum;

namespace IMAS.UI.Controllers
{
    public class VisitorServiceController : BaseController
    {
        public UserProfileService UserProfileService { get; set; }

        public VisitorServiceController()
        {
            UserProfileService = new UserProfileService();
        }

        [Route("visitorservice/getprofileimage/{userId}/{imageSize}/{anything?}", Name = "V-GetProfileImage")]
        //[OutputCache(
        //Duration = 3600,
        //VaryByParam = "userId",
        //Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetProfileImage(int userId, string imageSize, string anything)
        {
            ProfileImageSize profileImageSize;
            string mime, path;
            if (!Enum.TryParse<ProfileImageSize>(imageSize, true, out profileImageSize))
                profileImageSize = ProfileImageSize.Small;

            if (!UserProfileService.TryGetProfileImageFilePath(userId, profileImageSize, out path, out mime)) {
                path = StaticResourceHelper.GetAnonymousUserIconPhysicalPath(profileImageSize);
                mime = "image/png";
            }

            return File(path, mime);
        }
    }
}