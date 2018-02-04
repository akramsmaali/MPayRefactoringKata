using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        private readonly IUserSession _userSession;
        private readonly WalletDAO _walletDao;

        public WalletService(IUserSession userSession, WalletDAO walletDao)
        {
            _userSession = userSession;
            _walletDao = walletDao;
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
                    walletList = _walletDao.FindWalletsByUser(user);
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