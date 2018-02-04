using System.Linq;
using NUnit.Framework;
using WalletKata.Users;

namespace WalletKata.Test
{
    class UserTests
    {
        [Test]
        public void TestAddFriendToUser()
        {
            var user = new User(1);
            user.AddFriend(new User(2));
            Assert.That(user.GetFriends().Count(), Is.EqualTo(1));
        }
    }
}
