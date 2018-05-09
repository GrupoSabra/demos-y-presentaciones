using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.SmartContracts;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

namespace Ethereum.Labs.Lab1.Entities
{
    public class ApplicantV3 : ApplicantV2
    {
        public ApplicantV3(string enrollmentContractAddress)
            : base(enrollmentContractAddress)
        { }

        public async Task<bool> SignUpAsync(PlanTier plan, BigInteger payment)
        {
            var receipt = await _signUpFunction.SendTransactionAndWaitForReceiptAsync(Account.Address, new HexBigInteger(900000), new HexBigInteger(payment), null, (byte)plan);
            return receipt.Status.Value == 1;
        }

        public new async Task<RegistrationStatusV3> GetStatusAsync()
        {
            return await _applicantsFunction.CallDeserializingToObjectAsync<RegistrationStatusV3>(Account.Address);
        }
    }
}
