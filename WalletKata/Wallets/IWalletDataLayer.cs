using System.Collections.Generic;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public interface IWalletDataLayer
    {
        List<Wallet> FindWalletsByUser(User user);
    }
}