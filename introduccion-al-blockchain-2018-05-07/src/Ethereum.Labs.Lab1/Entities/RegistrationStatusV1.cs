using System;
using System.Collections.Generic;
using System.Text;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Ethereum.Labs.Lab1.Entities
{
    [FunctionOutput]
    public class RegistrationStatusV1
    {
        [Parameter("address", "accountAddress", 1)]
        public string AccountAddress { get; set; }

        [Parameter("uint8", "plan", 2)]
        public byte PlanId { get; set; }

        public PlanTier Plan => (PlanTier)PlanId;
    }
}
