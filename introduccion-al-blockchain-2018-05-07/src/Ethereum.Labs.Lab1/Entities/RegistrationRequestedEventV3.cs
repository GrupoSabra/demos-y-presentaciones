using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Ethereum.Labs.Lab1.Entities
{
    public class RegistrationRequestedEventV3
    {
        [Parameter("uint8", "plan", 1, true)]
        public Byte PlanId { get; set; }

        [Parameter("address", "sender", 2, false)]
        public string Sender { get; set; }

        [Parameter("uint256", "payment", 3, false)]
        public BigInteger Payment { get; set; }

        public PlanTier Plan => (PlanTier)PlanId;
    }
}
