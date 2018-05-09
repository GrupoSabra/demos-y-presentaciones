using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.Entities;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class ContractPaymentTests
    {
        [Fact]
        public async Task InvokeAContractSendingSomeWeis()
        {
            var serviceProvider = new ServiceProviderV3();

            Assert.Equal((BigInteger)0, await serviceProvider.GetContractBalanceAsync());

            var applicant1 = new ApplicantV3(serviceProvider.ContractAddress);
            var applicant2 = new ApplicantV3(serviceProvider.ContractAddress);
            var applicant3 = new ApplicantV3(serviceProvider.ContractAddress);
            var applicant4 = new ApplicantV3(serviceProvider.ContractAddress);

            Assert.True(await applicant1.SignUpAsync(PlanTier.Free, 0));
            Assert.False(await applicant1.SignUpAsync(PlanTier.Standard, 100));
            Assert.False(await applicant2.SignUpAsync(PlanTier.Standard, 50));
            Assert.True(await applicant3.SignUpAsync(PlanTier.Premium, 200));
            Assert.True(await applicant4.SignUpAsync(PlanTier.Standard, 100));

            var status = await applicant1.GetStatusAsync();

            Assert.True(status.Valid);
            Assert.Equal(applicant1.Account.Address, status.AccountAddress, true);
            Assert.Equal(PlanTier.Free, status.Plan);
            Assert.Equal((BigInteger)0, status.Payment);

            status = await applicant2.GetStatusAsync();

            Assert.False(status.Valid);
            Assert.Equal("0x0000000000000000000000000000000000000000", status.AccountAddress, true);
            Assert.Equal(PlanTier.Free, status.Plan);
            Assert.Equal((BigInteger)0, status.Payment);

            status = await applicant3.GetStatusAsync();

            Assert.True(status.Valid);
            Assert.Equal(applicant3.Account.Address, status.AccountAddress, true);
            Assert.Equal(PlanTier.Premium, status.Plan);
            Assert.Equal((BigInteger)200, status.Payment);

            status = await applicant4.GetStatusAsync();

            Assert.True(status.Valid);
            Assert.Equal(applicant4.Account.Address, status.AccountAddress, true);
            Assert.Equal(PlanTier.Standard, status.Plan);
            Assert.Equal((BigInteger)100, status.Payment);

            Assert.Equal((BigInteger)300, await serviceProvider.GetContractBalanceAsync());

            var log = await serviceProvider.GetAllRegistrationEventsAsync();

            Assert.Equal(3, log.Count);

            Assert.Equal(PlanTier.Free, log[0].Plan);
            Assert.Equal((BigInteger)0, log[0].Payment);

            Assert.Equal(PlanTier.Premium, log[1].Plan);
            Assert.Equal((BigInteger)200, log[1].Payment);

            Assert.Equal(PlanTier.Standard, log[2].Plan);
            Assert.Equal((BigInteger)100, log[2].Payment);
        }
    }
}
