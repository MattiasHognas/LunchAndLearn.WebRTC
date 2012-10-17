using System.Collections.Concurrent;
using System.Threading.Tasks;
using SignalR;
using SignalR.Hubs;
using WebRTC.WebSocketServer.SimpleHub;

namespace WebRTC.WebSocketServer.MultiHub
{
    public class MultiHub : Hub, IDisconnect
    {
        private static MultiHub _instance;
        private static readonly ConcurrentDictionary<string, string> Users = new ConcurrentDictionary<string, string>();

        public static MultiHub Instance
        {
            get { return _instance ?? (_instance = new MultiHub()); }
        }

        public Task Login(SimpleHubMessage message)
        {
            Users.TryAdd(Context.ConnectionId, message.From);
            message.Users = Users;
            message.From = Context.ConnectionId;
            return GetUsers(message);
        }

        public Task Offer(SimpleHubMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MultiHub>();
            message.Users = Users;
            message.From = Context.ConnectionId;
            return context.Clients[message.To].onoffer(message);
        }

        public Task Answer(SimpleHubMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MultiHub>();
            message.Users = Users;
            message.From = Context.ConnectionId;
            return context.Clients[message.To].onanswer(message);
        }

        public Task Candidate(SimpleHubMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MultiHub>();
            message.Users = Users;
            message.From = Context.ConnectionId;
            return context.Clients[message.To].oncandidate(message);
        }

        public Task Disconnect()
        {
            string value;
            Users.TryRemove(Context.ConnectionId, out value);
            var message = new SimpleHubMessage {Users = Users, From = Context.ConnectionId};
            return GetUsers(message);
        }

        private Task GetUsers(SimpleHubMessage message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MultiHub>();
            message.Users = Users;
            message.From = Context.ConnectionId;
            return context.Clients.onusers(message);
        }
    }
}
