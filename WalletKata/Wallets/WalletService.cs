using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        private readonly IUserSession _userSession;

        public WalletService(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public List<Wallet> GetWalletsByUser(User user)
        {
            List<Wallet> walletList = new List<Wallet>();
            var loggedUser = _userSession.GetLoggedUser();
            var isFriend = false;

            if (loggedUser != null)
            {
                foreach (var friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    walletList = WalletDAO.FindWalletsByUser(user);
                }

                return walletList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }      
        }         
    }
}