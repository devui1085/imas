using System.Web.Mvc;
using IMAS.Security.Identity;

namespace IMAS.UI
{
    public abstract class BaseWebViewPage : WebViewPage
    {
        public virtual new UserIdentity User
        {
            get { return base.User as UserIdentity; }
        }
    }

    public abstract class BaseWebViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new UserIdentity User
        {
            get { return base.User as UserIdentity; }
        }
    }
}