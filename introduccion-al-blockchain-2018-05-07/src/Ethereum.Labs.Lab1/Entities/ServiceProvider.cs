using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

namespace Ethereum.Labs.Lab1.Entities
{
    public abstract class ServiceProvider : EnrollmentSystemActor
    {
        protected readonly Contract _enrollmentContract;

        public ServiceProvider()
        {
            var createContractReceipt = _web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(
                ContractABI,
                ContractBIN,
                Account.Address,
                new HexBigInteger(900000)).Result;

            _enrollmentContract = _web3.Eth.GetContract(
                ContractABI,
                createContractReceipt.ContractAddress);

            ContractAddress = createContractReceipt.ContractAddress;
        }

        public abstract string ContractABI { get; }
        public abstract string ContractBIN { get; }

        public string ContractAddress { get; }

        public async Task<BigInteger> GetContractBalanceAsync()
        {
            return (await _web3.Eth.GetBalance.SendRequestAsync(ContractAddress)).Value;
        }
    }
}
