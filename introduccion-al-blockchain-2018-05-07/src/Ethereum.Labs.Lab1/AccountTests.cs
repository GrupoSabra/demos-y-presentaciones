using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Common;
using Nethereum.KeyStore;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class AccountTests
    {
        [Fact]
        public async Task GetPrefundedAccountUsingFromWallet()
        {
            var web3 = new Web3(EthTestNet.TESTNET_URL);

            var prefundedAccountAddress = EthTestNet.PREFUNDED_ACCOUNT_ADDRESS;
            var prefundedAccountPassword = EthTestNet.PREFUNDED_ACCOUNT_PASSWORD;
            var prefundedAccount = new ManagedAccount(prefundedAccountAddress, prefundedAccountPassword);

            Assert.True(await web3.Personal.UnlockAccount.SendRequestAsync(prefundedAccount.Address, prefundedAccountPassword, (int?)null));
        }

        [Fact]
        public void GetPrefundedAccountFromKeyStoreJson()
        {
            var accountKeyStoreEncryptedJson = @"{""address"":""25167c9832306456af507a0918c3bf48bf5caa0d"",""crypto"":{""cipher"":""aes-128-ctr"",""ciphertext"":""32a353df21a02eb511c9425a566507d9249ea312b62e2b6efe9e087310586eef"",""cipherparams"":{""iv"":""f204622c4e6ee2ebc4cfa7254c178429""},""kdf"":""scrypt"",""kdfparams"":{""dklen"":32,""n"":262144,""p"":1,""r"":8,""salt"":""71c29347301c3c06e2deaf8cf8712759bc8ced46a3e7ef4de492a3b034eb99d9""},""mac"":""1731f188d4175953638fb6deb03278b086e180a4687ef16d5bb80cc09c99ad5e""},""id"":""d0f55980-edb0-4c79-ad22-0a44ddc9efc6"",""version"":3}";
            var accountPassword = EthTestNet.PREFUNDED_ACCOUNT_PASSWORD;
            var account = Account.LoadFromKeyStore(accountKeyStoreEncryptedJson, accountPassword);

            //Assert.Equal("0x00fd51ce64bd64335843b8d6954a4ee33a092c3f905b7e4173601b66110a2811a2", account.PrivateKey);
            Assert.Equal("0x00fd51ce64bd64335843b8d6954a4ee33a092c3f905b7e4173601b66110a2811a1", account.PrivateKey);
        }
    }
}
