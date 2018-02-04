using System.Collections.Generic;
using WalletKata.Exceptions;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public class WalletDAL : IWalletDataLayer
    {
        public List<Wallet> FindWalletsByUser(User user)
        {
            throw new ThisIsAStubException("WalletDAL.FindWalletsByUser() should not be called in an unit test");
        }

    }
}