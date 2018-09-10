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
        public const string TESTNET_URL = "http://10.4.0.4:8545";
        public const string PREFUNDED_ACCOUNT_ADDRESS = "0xbf27449A7362199C98115E1A31ee219c2eA690C1";
        public const string PREFUNDED_ACCOUNT_PASSWORD = "sab-eth1007";

        public static async Task<IAccount> GetPrefundedAccountAsync()
        {
            var web3 = new Web3(TESTNET_URL);

            var prefundedAccountAddress = PREFUNDED_ACCOUNT_ADDRESS;
            var prefundedAccountPassword = PREFUNDED_ACCOUNT_PASSWORD;
            var prefundedAccount = new ManagedAccount(prefundedAccountAddress, prefundedAccountPassword);

            if (!await web3.Personal.UnlockAccount.SendRequestAsync(prefundedAccount.Address, prefundedAccountPassword, (ulong?)null))
            {
                throw new Exception("Unable to unlock account.");
            }

            return prefundedAccount;
        }
    }
}
