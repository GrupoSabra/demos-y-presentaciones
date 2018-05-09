using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.SmartContracts;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

namespace Ethereum.Labs.Lab1.Entities
{
    public class ApplicantV1 : EnrollmentSystemActor
    {
        protected readonly Contract _enrollmentContract;
        protected readonly Function _signUpFunction;
        protected readonly Function _applicantsFunction;

        public ApplicantV1(string enrollmentContractAddress)
        {
            _enrollmentContract = _web3.Eth.GetContract(
                Contracts.Instance.EnrollmentV1ABI,
                enrollmentContractAddress);

            _signUpFunction = _enrollmentContract.GetFunction("signUp");
            _applicantsFunction = _enrollmentContract.GetFunction("applicants");
        }

        public async Task SignUpAsync(PlanTier plan)
        {
            await _signUpFunction.SendTransactionAndWaitForReceiptAsync(Account.Address, new HexBigInteger(900000), null, null, (byte)plan);
        }

        public async Task<RegistrationStatusV1> GetStatusAsync()
        {
            return await _applicantsFunction.CallDeserializingToObjectAsync<RegistrationStatusV1>(Account.Address);
        }
    }
}
