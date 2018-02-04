using System.Collections.Generic;
using System.Linq;
using Moq;
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
        private Mock<WalletDAO> _walletDaoMock;

        [SetUp]
        public void SetUp()
        {
            _userSession = new UserSessionMock();
            _walletDaoMock = new Mock<WalletDAO>();
            _walletService = new WalletService(_userSession, _walletDaoMock.Object);
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
        public void GetWalletOf_Logged_Friend_Should_Return_Users_Wallet()
        {
            //create user and attach a friend to it
            var user = new User();
            var friend = new User();
            user.AddFriend(friend);
            _userSession.LoggedUser = friend;

            //create wallet and attach it to the user
            var userWallet1 = new Wallet();
            var userWallet2 = new Wallet();
            var wallets = new List<Wallet>() {userWallet1,userWallet2};
            _walletDaoMock.Setup(dao => dao.FindWalletsByUser(user)).Returns(wallets);

            //walletService should return same list
            CollectionAssert.AreEqual(_walletService.GetWalletsByUser(user), wallets);
        }

    }
}