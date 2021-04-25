using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using IMAS.Facade.Net;

namespace IMAS.UI.SignalR
{
    public class UsersHub : Hub
    {
        public override Task OnConnected()
        {
            var userId = Int32.Parse(Context.User.Identity.Name);
            OnlineUsers.SetUserAsOnline(userId, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userId = Int32.Parse(Context.User.Identity.Name);
            OnlineUsers.SetUserAsOffline(userId, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            var userId = Int32.Parse(Context.User.Identity.Name);
            OnlineUsers.SetUserAsOnline(userId, Context.ConnectionId);
            return base.OnReconnected();
        }
    }
}