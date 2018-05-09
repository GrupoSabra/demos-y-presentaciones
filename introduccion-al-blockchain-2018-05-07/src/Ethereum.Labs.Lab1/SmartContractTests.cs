using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Common;
using Ethereum.Labs.Lab1.SmartContracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class SmartContractTests
    {
        [Fact]
        public async Task PublishAndInvokeSmartContract()
        {
            var web3 = new Web3(EthTestNet.TESTNET_URL);

            var account = EthAccountFactory.Create();

            await account.RefillAsync(1);

            web3 = new Web3(account, EthTestNet.TESTNET_URL);

            var createContractReceipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(
                Contracts.Instance.CounterABI,
                Contracts.Instance.CounterBIN,
                account.Address,
                new HexBigInteger(900000));

            var contract = web3.Eth.GetContract(
                Contracts.Instance.CounterABI,
                createContractReceipt.ContractAddress);

            var incrementFunction = contract.GetFunction("increment");
            var getCountFunction = contract.GetFunction("getCount");

            uint counter = 0;

            var incrementReceipt1 = await incrementFunction.SendTransactionAndWaitForReceiptAsync(account.Address, new HexBigInteger(900000), null);

            counter = await getCountFunction.CallAsync<uint>();

            Assert.Equal((uint)1, counter);

            var incrementReceipt2 = await incrementFunction.SendTransactionAndWaitForReceiptAsync(account.Address, new HexBigInteger(900000), null);

            counter = await getCountFunction.CallAsync<uint>();

            Assert.Equal((uint)2, counter);
        }
    }
}
