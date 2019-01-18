using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Kurento;
using KurentoDemo.Hubs;
using KurentoDemo.Infrastructure.Hub;
using KurentoDemo.Infrastructure.Kurento;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using KMS = Kurento.NET;

namespace KurentoDemo
{
    public class RoomHub : Hub
    {

        private readonly RoomsManager roomsManager;
        private readonly UsersManager usersManager;
        private readonly KMSServersManager serversManager;
        public RoomHub(RoomsManager roomsManager, UsersManager usersManager, KMSServersManager serversManager)
        {
            this.roomsManager = roomsManager;
            this.usersManager = usersManager;
            this.serversManager = serversManager;
        }
        public string ClientId
        {
            get
            {
                return Context.HttpContext.Request.Query["clientId"];
            }
        }
        public string UserName
        {
            get
            {
                return Context.HttpContext.Request.Query["userName"];
            }
        }
        public string RoomName
        {
            get
            {
                return Context.HttpContext.Request.Query["roomName"];
            }
        }
        public User User
        {
            get
            {
                return usersManager.Get(ClientId);
            }
        }
        public Room Room
        {
            get
            {
                return roomsManager.GetRoom(RoomName);
            }
        }
        public dynamic Caller
        {
            get
            {
                return new DynamicClientProxy(new WebSocket[] { Context.WebSocket });
            }
        }
        public dynamic Others
        {
            get
            {
                var sockets = Room.Users
                    .Where(x => x.Id != ClientId)
                    .Select(x => x.WebSocket)
                    .ToArray();
                return new DynamicClientProxy(sockets);
            }
        }
        public dynamic All
        {
            get
            {
                var sockets = Room.Users
                     .Select(x => x.WebSocket)
                     .ToArray();
                return new DynamicClientProxy(sockets);
            }
        }
        public dynamic Clients(params string[] ids)
        {
            var sockets = Room.Users.Where(x => ids.Contains(x.Id))
                .Select(x => x.WebSocket)
                .ToArray();
            return new DynamicClientProxy(sockets);
        }
        public override Task OnConnectedAsync()
        {
            var room = roomsManager.GetRoom(RoomName);
            var user = room.AddUser(ClientId, UserName, Context.WebSocket);
            usersManager.Add(user);
            Caller.InitRoom(room);
            Others.AddUser(user);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception ex)
        {
            Room.RemoveUser(ClientId);
            usersManager.Remove(ClientId);
            Others.RemoveUser(ClientId);
            return base.OnDisconnectedAsync(ex);
        }
        public void ModifyUserType(string id, UserType type)
        {
            var user = usersManager.Get(id);
            user.Type = type;
            if (type == UserType.Receiver)
            {
                user.SendEndPoint.Dispose();
                user.SendEndPoint = null;
                foreach (var u in Room.Users)
                {
                    if (u.ReceiveEndPoints.TryRemove(user.Id, out KMS.WebRtcEndpoint w))
                    {
                        w.Dispose();
                    }
                }
            }
            All.ModifyUser(user);
        }
        private KMS.WebRtcEndpoint GetEndPoint(string id)
        {
            if (id == ClientId)
            {
                if (User.SendEndPoint == null)
                {
                    User.SendEndPoint = serversManager.CreateMasterWebRtcEndPoint(RoomName);
                    User.SendEndPoint.OnIceCandidate += arg => Caller.AddCandidate(id, arg.candidate);
                }
                return User.SendEndPoint;
            }
            else
            {
                var sender = usersManager.Get(id);
                if (sender.SendEndPoint == null)
                {
                    sender.SendEndPoint = serversManager.CreateMasterWebRtcEndPoint(RoomName);
                    sender.SendEndPoint.OnIceCandidate += arg => Clients(id).AddCandidate(id, arg.candidate);
                }
                if (!User.ReceiveEndPoints.TryGetValue(id, out KMS.WebRtcEndpoint receiveEndPoint))
                {
                    receiveEndPoint = serversManager.CreateSlaveWebRtcEndPoint(RoomName);
                    receiveEndPoint.OnIceCandidate += arg => Caller.AddCandidate(id, arg.candidate);
                    User.ReceiveEndPoints[id] = receiveEndPoint;
                }
                return receiveEndPoint;
            }
        }
        /// <summary>
        /// 处理offer
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="sdpOffer">offer</param>
        /// <returns></returns>
        public void ReceiveOffer(string clientId, string id, string sdpOffer)
        {
            //根据id 获取端点
            //若 接收端点， 则与发送端 客户端 进行连接 
            var endPoint = GetEndPoint(id);
            //处理offer
            var answer = endPoint.ProcessOffer(sdpOffer);
            //caller 处理answer
            Caller.ProcessAnswer(id, answer);
            //开始收集 candidate
            endPoint.GatherCandidates();
        }
        /// <summary>
        /// 添加候选项
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="candidate">候选项</param>
        /// <returns></returns>
        public void AddCandidate(string id, KMS.IceCandidate candidate)
        {
            var endPoint = GetEndPoint(id);
            endPoint.AddIceCandidate(candidate);
        }

        public void Ping()
        {
            Caller.Pong();
        }
    }
}
