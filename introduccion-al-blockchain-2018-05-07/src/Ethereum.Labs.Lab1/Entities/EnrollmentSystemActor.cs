using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Common;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;

namespace Ethereum.Labs.Lab1.Entities
{
    public abstract class EnrollmentSystemActor
    {
        protected readonly Web3 _web3;

        public EnrollmentSystemActor()
        {
            Account = EthAccountFactory.Create();
            _web3 = new Web3(Account, EthTestNet.TESTNET_URL);
            Account.RefillAsync(1).Wait();
        }

        public IAccount Account { get; }
    }
}
