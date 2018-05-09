using System;
using System.Collections.Generic;
using System.Text;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Accounts;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;

namespace Ethereum.Labs.Common
{
    public static class EthAccountFactory
    {
        public static IAccount Create()
        {
            var accountEcKey = EthECKey.GenerateKey();
            var accountPrivateKey = accountEcKey.GetPrivateKeyAsBytes().ToHex();
            return new Account(accountPrivateKey);
        }
    }
}
