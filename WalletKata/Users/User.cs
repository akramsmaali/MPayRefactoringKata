using System.Collections.Generic;

namespace WalletKata.Users
{
    public class User
    {
        private readonly List<User> _friends = new List<User>();

        //reuse id from session or database to guarantee equality 
        //and avoid infinite equality tests for friends (when friend has this as friend) potential stackoverflow
        private readonly ulong _id;

        public User(ulong id)
        {
            _id = id;
        }
        public IEnumerable<User> GetFriends()
        {
            return _friends;
        }

        public void AddFriend(User friend)
        {
            _friends.Add(friend);
        }

        protected bool Equals(User other)
        {
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}