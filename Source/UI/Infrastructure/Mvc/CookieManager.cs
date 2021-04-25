using System.Web.Security;
using IMAS.Security.Identity;

namespace IMAS.UI.Infrastructure.Mvc
{
    public static class CookieManager
    {
        public static void WriteAuthenticationCookie(UserIdentity user, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(user.UserId.ToString(), rememberMe);
        }

        public static void RemoveAuthenticationCookie()
        {
            FormsAuthentication.SignOut();
        }
    }
}