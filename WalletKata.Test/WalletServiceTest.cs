using System.Collections.Generic;
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
        private Mock<IWalletDataLayer> _walletDalMock;

        [SetUp]
        public void SetUp()
        {
            _userSession = new UserSessionMock();
            _walletDalMock = new Mock<IWalletDataLayer>();
            _walletService = new WalletService(_userSession, _walletDalMock.Object);
        }


        [Test]
        public void GetWallet_Of_NotLoggedInUser_Should_Throw_NotLoggedException()
        {
            var user = new User(1);
            Assert.Throws<UserNotLoggedInException>(() => _walletService.GetWalletsByUser(user));
        }

        [Test]
        public void GetWalletOf_LoggedInUser_And_Is_Not_A_Friend_Should_Return_Empty_List()
        {
            var user = new User(1);
            _userSession.LoggedUser = user;
            CollectionAssert.IsEmpty(_walletService.GetWalletsByUser(user));
        }
   

        [Test]
        public void GetWalletOf_LoggedInFriend_Should_Return_Users_Wallet()
        {
            //create user and attach a friend to it
            var user = new User(1);
            var friend = new User(2);
            user.AddFriend(friend);

            //login the friend
            _userSession.LoggedUser = friend;

            //create wallets and attach it to the user
            var userWallet1 = new Wallet();
            var userWallet2 = new Wallet();
            var wallets = new List<Wallet>() {userWallet1,userWallet2};
            _walletDalMock.Setup(dao => dao.FindWalletsByUser(user)).Returns(wallets);

            //walletService should return same list
            CollectionAssert.AreEqual(_walletService.GetWalletsByUser(user), wallets);
        }

    }
}