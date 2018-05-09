using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;

namespace Ethereum.Labs.Common
{
    public static class EthTestNet
    {
        public const string TESTNET_URL = "http://10.4.0.5:8545";
        public const string PREFUNDED_ACCOUNT_ADDRESS = "3e5e985ab7629d74926e73de46e85995b97e2e60";
        public const string PREFUNDED_ACCOUNT_PASSWORD = "1234";

        public static async Task<IAccount> GetPrefundedAccountAsync()
        {
            var web3 = new Web3(TESTNET_URL);

            var prefundedAccountAddress = PREFUNDED_ACCOUNT_ADDRESS;
            var prefundedAccountPassword = PREFUNDED_ACCOUNT_PASSWORD;
            var prefundedAccount = new ManagedAccount(prefundedAccountAddress, prefundedAccountPassword);

            if (!await web3.Personal.UnlockAccount.SendRequestAsync(prefundedAccount.Address, prefundedAccountPassword, (int?)null))
            {
                throw new Exception("Unable to unlock account.");
            }

            return prefundedAccount;
        }
    }
}
