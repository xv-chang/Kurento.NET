using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Kurento.NET;
using Microsoft.Extensions.Logging;
using KurentoDemo.Infrastructure.Kurento;

namespace KurentoDemo.Hubs
{
    public class RoomsManager
    {
        private readonly ConcurrentDictionary<string, Room> rooms;
        private readonly KMSServersManager serversManager;

        public RoomsManager(KMSServersManager serversManager)
        {
            this.serversManager = serversManager;
            rooms = new ConcurrentDictionary<string, Room>();
        }

        public Room GetRoom(string roomName)
        {
            if (!rooms.TryGetValue(roomName, out Room room))
            {
                serversManager.CreatePipeline(roomName);
                room = new Room()
                {
                    Name = roomName,
                    Users = new List<User>()
                };
                rooms[roomName] = room;
            }
            return room;
        }
    }


}
