using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Ethereum.Labs.Lab1.Entities
{
    [FunctionOutput]
    public class RegistrationStatusV3
    {
        [Parameter("bool", "valid", 1)]
        public bool Valid { get; set; }

        [Parameter("address", "accountAddress", 2)]
        public string AccountAddress { get; set; }

        [Parameter("uint8", "plan", 3)]
        public byte PlanId { get; set; }

        [Parameter("uint256", "payment", 4)]
        public BigInteger Payment { get; set; }

        public PlanTier Plan => (PlanTier)PlanId;
    }
}
