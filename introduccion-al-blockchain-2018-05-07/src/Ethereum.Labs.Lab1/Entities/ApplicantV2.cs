using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.SmartContracts;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

namespace Ethereum.Labs.Lab1.Entities
{
    public class ApplicantV2 : ApplicantV1
    {
        public ApplicantV2(string enrollmentContractAddress)
            : base(enrollmentContractAddress)
        { }
    }
}
