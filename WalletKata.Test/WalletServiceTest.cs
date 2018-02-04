using NUnit.Framework;
using WalletKata.Users;
using WalletKata.Exceptions;
using WalletKata.Wallets;

namespace WalletKata.Test
{
    public class WalletServiceTest
    {
        private UserSessionMock _userSession;
        private WalletService _walletService;

        [SetUp]
        public void SetUp()
        {
            _userSession = new UserSessionMock();
            _walletService = new WalletService(_userSession);

        }


        [Test]
        public void GetWallet_Of_UnLoggedUser_Should_Throw_NotLoggedException()
        {
            var user = new User();
            Assert.Throws<UserNotLoggedInException>(() => _walletService.GetWalletsByUser(user));
        }

        [Test]
        public void GetWalletOf_LoggedUser_And_Not_A_Friend_Should_Return_Empty_List()
        {
            var user = new User();
            _userSession.LoggedUser = user;
            CollectionAssert.IsEmpty(_walletService.GetWalletsByUser(user));
        }
   

        [Test]
        public void GetWalletOf_Logged_Friend_Should_Call_FindWalletsByUser()
        {
            var user = new User();
            var friend = new User();
            user.AddFriend(friend);

            _userSession.LoggedUser = friend;
            Assert.Throws<ThisIsAStubException>(() => _walletService.GetWalletsByUser(user));
        }

    }
}