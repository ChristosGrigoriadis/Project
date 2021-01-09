using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UberTappDeveloping.Models
{
    [Authorize]
    public class ChatHub : Hub
    {
        static private List<ConnectedUser> ConnectedUsers = new List<ConnectedUser>();

        private string CurrentUserId => Context.User.Identity.GetUserId();
        private string CurrentUserConnectionId => Context.ConnectionId;
        private string CurrentUserName => Context.User.Identity.Name;


        public override Task OnConnected()
        {
            CreateConnection();

            return base.OnConnected();
        }

        public void Send(string userId, string message)
        {
            Message message2 = new Message
            {
                UserName = Context.User.Identity.Name,
                Content = message,
                TimeSent = DateTime.Now
            };

            var message1 = JsonConvert.SerializeObject(message2);

            string toWho = ConnectedUsers.First(cu => cu.UserId == userId).ConnectionId;

            var currentUser = ConnectedUsers.SingleOrDefault(cu => cu.UserId == CurrentUserId);

            Clients.Client(toWho).receive(message1);

        }

        private void CreateConnection()
        {
            var conUser = ConnectedUsers.SingleOrDefault(cu => cu.UserId == CurrentUserId);

            if (conUser == null)
            {
                var chatter = ConnectedUser.CreateConnectedUser(CurrentUserId, CurrentUserConnectionId);
                ConnectedUsers.Add(chatter);
            }
            else
            {
                conUser.ConnectionId = CurrentUserId;
            }
        }
    }
}