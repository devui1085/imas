using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.Common.Enum;
using IMAS.Security.Identity;

namespace IMAS.UI.Infrastructure.Mvc
{
    public static class SessionManager
    {
        public static void StoreUserIdentity(UserIdentity user)
        {
            HttpContext.Current.Session[SessionKeys.UserIdentity.ToString()] = user;
        }

        public static UserIdentity GetUserIdentity()
        {
            return HttpContext.Current.Session[SessionKeys.UserIdentity.ToString()] as UserIdentity;
        }

        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}