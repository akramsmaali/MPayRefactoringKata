using WalletKata.Users;

namespace WalletKata.Test
{
    internal class UserSessionMock : IUserSession
    {
        public User LoggedUser { get; set; }

        public User GetLoggedUser()
        {
            return LoggedUser;
        }
    }
}
