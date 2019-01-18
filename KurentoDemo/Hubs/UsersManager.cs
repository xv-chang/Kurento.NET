using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace KurentoDemo.Hubs
{
    public class UsersManager
    {
        private readonly ConcurrentDictionary<string, User> users;

        public UsersManager()
        {
            users = new ConcurrentDictionary<string, User>();
        }
        public User Get(string key)
        {
            users.TryGetValue(key, out User user);
            return user;
        }
        public void Add(User user)
        {
            users.TryAdd(user.Id, user);
        }
        public void Remove(string id)
        {
            users.TryRemove(id, out User _);
        }
    }
}
