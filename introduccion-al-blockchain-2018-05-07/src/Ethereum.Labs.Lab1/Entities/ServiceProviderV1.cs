using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.SmartContracts;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

namespace Ethereum.Labs.Lab1.Entities
{
    public class ServiceProviderV1 : ServiceProvider
    {
        public override string ContractABI => Contracts.Instance.EnrollmentV1ABI;
        public override string ContractBIN => Contracts.Instance.EnrollmentV1BIN;
    }
}
