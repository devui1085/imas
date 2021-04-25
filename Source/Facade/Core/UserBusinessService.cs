using IMAS.Bussines.Core;
using System.Linq;
using System.Data.Entity;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using IMAS.PresentationModel.Model;
using IMAS.Mapper.Core;
using IMAS.Model.Domain.Core;
using System.Collections.Generic;
using IMAS.Common.Enum;
using System.IO;
using Common.Exception;
using IMAS.Localization.ExtensionMethod;
using System.Drawing;
using IMAS.Common.Configuration;
using IMAS.Common.Drawing;
using System.Drawing.Imaging;
using IMAS.Common.IO;
using IMAS.PresentationModel.ModelContainer;
using IMAS.Common.ExtensionMethod;
using IMAS.PresentationModel.Model.Organization;
using IMAS.Common.Globalization;
using System;
using IMAS.PresentationModel.Model.Business;

namespace IMAS.Facade.Core
{
    public class UserBusinessService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        UserBiz UserBiz { get; set; }
        MembershipBiz MembershipBiz { get; set; }
        ProfileBiz ProfileBiz { get; set; }
        ArticleBiz ArticleBiz { get; set; }
        BlogBiz BlogBiz { get; set; }
        VisitBiz VisitBiz { get; set; }
        JobResumeBiz JobResumeBiz { get; set; }
        EducationalResumeBiz EducationalResumeBiz { get; set; }
        FollowBiz FollowBiz { get; set; }

        public UserBusinessService()
        {
            UnitOfWork = new CoreUnitOfWork();
            UserBiz = new UserBiz(UnitOfWork);
            MembershipBiz = new MembershipBiz(UnitOfWork);
            ProfileBiz = new ProfileBiz(UnitOfWork);
            ArticleBiz = new ArticleBiz(UnitOfWork);
            BlogBiz = new BlogBiz(UnitOfWork);
            EducationalResumeBiz = new EducationalResumeBiz(UnitOfWork);
            VisitBiz = new VisitBiz(UnitOfWork);
            JobResumeBiz = new JobResumeBiz(UnitOfWork);
            FollowBiz = new FollowBiz(UnitOfWork);
        }

        #region General Settings
        public BusinessIntroducePM ReadUserBusinesIntroduce(int userId)
        {
            string text;
            return new BusinessIntroducePM() {
                Text = ProfileBiz.TryReadUserProfileValue(userId, ProfileKeyValueType.UserBusinessIntroduceText, out text) ?
                    text : ""
            };
        }

        public void UpdateBusinesIntroduce(UserIdentity userIdentity, BusinessIntroducePM businessIntroduce)
        {
            ProfileBiz.SetUserProfile(userIdentity.UserId, ProfileKeyValueType.UserBusinessIntroduceText, businessIntroduce.Text);
            UnitOfWork.SaveChanges();
        }
        #endregion
    }
}
