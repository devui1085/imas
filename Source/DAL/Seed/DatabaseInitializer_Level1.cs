using System;
using IMAS.Common.Enum;
using IMAS.Model.Domain.Core;
using IMAS.Security.Helper;

namespace IMAS.DataAccess.Seed
{
    public static class DatabaseInitializer_Level1
    {
        public static void Initialize()
        {
            var context = new IMASModel();

            #region Roles
            var role1 = new Role()
            {
                Name = "admin",
                Title = "مدیر ارشد"
            };
            var role2 = new Role()
            {
                Name = "moderator",
                Title = "مدیر"
            };
            context.Roles.AddRange(new Role[] { role1, role2 });
            #endregion

            #region Users
          
            var user2 = new User()
            {
                FirstName = "محمد",
                LastName = "انصاری",
                Email = "ansari.mohammad@outlook.com",
                Cellphone = "09129374401",
                Sexuality = Sexuality.Male,
                Membership = new Membership()
                {
                    CreateDate = DateTime.Now,
                    FailedPasswordAttemptCount = 0,
                    IsApproved = true,
                    IsLockedOut = false,
                    Password = HashHelper.ComputeSha256Hash("123456"),
                    VerificationCode = Guid.NewGuid(),
                    VerificationCodeSendDate = DateTime.Now,
                },
            };
            user2.Roles.Add(role1);
            user2.Roles.Add(role2);
            user2.Profiles.Add(new Profile() { Type = ProfileKeyValueType.AboutMe, Value = "This is me." });

            context.Users.AddRange(new User[] {  user2 });
            #endregion

            context.SaveChanges();
        }
    }
}
