using System;
using WalletKata.Exceptions;

namespace WalletKata.Users
{
    public class UserSession : IUserSession
    {
        private static readonly UserSession _userSession = new UserSession();

        private UserSession() { }

        public static UserSession GetInstance()
        {
            return _userSession;
        }

        User IUserSession.GetLoggedUser()
        {
            return GetInstance().GetLoggedUserFromSession();
        }

        private User GetLoggedUserFromSession()
        {
            throw new ThisIsAStubException("UserSession.IsUserLoggedIn() should not be called in an unit test");
        }
    }
}