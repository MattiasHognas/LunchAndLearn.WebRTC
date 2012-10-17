using System.Threading.Tasks;
using SignalR;
using SignalR.Hubs;
using WebRTC.WebSocketServer.MultiHub;

namespace WebRTC.WebSocketServer.SimpleHub
{
    public class SimpleHub : Hub
    {
        private static SimpleHub _instance;

        public static SimpleHub Instance
        {
            get { return _instance ?? (_instance = new SimpleHub()); }
        }

        public Task addMessage(MultiHubMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();
            return context.Clients.getMessage(message);
        }
    }
}
