using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class ConnectedUser
    {
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
        public string UserName { get; set; }

        public ConnectedUser() { }

        public ConnectedUser(string userId, string connectionId)
        {
            UserId = userId;
            ConnectionId = connectionId;
        }

        public static ConnectedUser CreateConnectedUser(string userId, string connectionId) => new ConnectedUser(userId, connectionId);
    }
}