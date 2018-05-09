using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Common;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Accounts;
using Nethereum.Util;
using Nethereum.Web3;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class TransactionTests
    {
        [Fact]
        public async Task TransferEthFromAccounts()
        {
            var web3 = new Web3(EthTestNet.TESTNET_URL);

            var account1 = await CreateNewAccountAndTransferFromPrefundedAccount(UnitConversion.Convert.ToWei(1));

            var balance1 = await web3.Eth.GetBalance.SendRequestAsync(account1.Address);

            Assert.Equal(UnitConversion.Convert.ToWei(1), balance1.Value);

            var account2 = await CreateNewAccountAndTransferFromCreatedAccount(account1, UnitConversion.Convert.ToWei(0.5));

            var balance2 = await web3.Eth.GetBalance.SendRequestAsync(account2.Address);

            Assert.Equal(UnitConversion.Convert.ToWei(0.5), balance2.Value);
        }

        private async Task<IAccount> CreateNewAccountAndTransferFromPrefundedAccount(BigInteger value)
        {
            var web3 = new Web3(EthTestNet.TESTNET_URL);

            var prefundedAccount = await EthTestNet.GetPrefundedAccountAsync();
            var destinationAccount = EthAccountFactory.Create();

            var recepit = await web3.TransactionManager.TransactionReceiptService.SendRequestAndWaitForReceiptAsync(() =>
                web3.TransactionManager.SendTransactionAsync(prefundedAccount.Address, destinationAccount.Address, new HexBigInteger(value))
            );

            return destinationAccount;
        }

        private async Task<IAccount> CreateNewAccountAndTransferFromCreatedAccount(IAccount sourceAccount, BigInteger value)
        {
            var web3 = new Web3(sourceAccount, EthTestNet.TESTNET_URL);

            var destinationAccount = EthAccountFactory.Create();

            var recepit = await web3.TransactionManager.TransactionReceiptService.SendRequestAndWaitForReceiptAsync(() =>
                web3.TransactionManager.SendTransactionAsync(sourceAccount.Address, destinationAccount.Address, new HexBigInteger(value))
            );

            return destinationAccount;
        }
    }
}
