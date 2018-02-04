using System.Collections.Generic;
using System.Linq;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        private readonly IUserSession _userSession;
        private readonly IWalletDataLayer _walletDal;

        public WalletService(IUserSession userSession, IWalletDataLayer walletDal)
        {
            _userSession = userSession;
            _walletDal = walletDal;
        }

        public List<Wallet> GetWalletsByUser(User user)
        {
            var loggedUser = _userSession.GetLoggedUser();

            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            var walletList = new List<Wallet>();

            if (user.GetFriends().Contains(loggedUser))
            {
                walletList = _walletDal.FindWalletsByUser(user);
            }

            return walletList;
            
        }         
    }
}