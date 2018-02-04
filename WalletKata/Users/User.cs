using System.Collections;
using System.Collections.Generic;

namespace WalletKata.Users
{
    public class User
    {
        private readonly List<User> _friends = new List<User>();

        public IEnumerable<User> GetFriends()
        {
            return _friends;
        }

        public void AddFriend(User friend)
        {
            _friends.Add(friend);
        }
    }
}