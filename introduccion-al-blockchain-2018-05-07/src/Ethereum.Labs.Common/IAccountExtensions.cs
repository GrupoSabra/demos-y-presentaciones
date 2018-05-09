using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Accounts;
using Nethereum.Util;
using Nethereum.Web3;

namespace Ethereum.Labs.Common
{
    public static class IAccountExtensions
    {
        public static async Task RefillAsync(this IAccount account, int ethers)
        {
            var web3 = new Web3(EthTestNet.TESTNET_URL);

            var prefundedAccount = await EthTestNet.GetPrefundedAccountAsync();

            var recepit = await web3.TransactionManager.TransactionReceiptService.SendRequestAndWaitForReceiptAsync(() =>
                web3.TransactionManager.SendTransactionAsync(prefundedAccount.Address, account.Address, new HexBigInteger(UnitConversion.Convert.ToWei(ethers)))
            );
        }
    }
}
