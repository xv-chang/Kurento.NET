using Kurento.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading.Tasks;

namespace KurentoDemo.Hubs
{
    public class Room
    {
        public List<User> Users { set; get; }
        public string Name { set; get; }
        public bool Exists(string userName)
        {
            return Users.Any(x => x.Name == userName);
        }
        public User AddUser(string id, string userName, WebSocket webSocket)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                user = new User()
                {
                    Id = id,
                    WebSocket = webSocket,
                    Name = userName,
                    ReceiveEndPoints = new ConcurrentDictionary<string, WebRtcEndpoint>(),
                    Type = UserType.Receiver
                };
                Users.Add(user);
            }
            else
            {
                user.Name = userName;
                user.WebSocket = webSocket;
            }
            return user;
        }
        public void RemoveUser(string id)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                var user = Users[i];
                if (user.Id == id)
                {
                    Users.Remove(user);
                }
                else
                {
                    user.ReceiveEndPoints.TryRemove(id, out WebRtcEndpoint _);
                }
            }
        }
    
    }
}
