using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IMAS.UI.Startup))]
namespace IMAS.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}