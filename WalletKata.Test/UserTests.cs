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
            var user = new User();
            user.AddFriend(new User());
            Assert.That(user.GetFriends().Count(), Is.EqualTo(1));
        }
    }
}
