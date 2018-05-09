using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.Entities;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class LogAndEventsTests
    {
        [Fact]
        public async Task EmitEventsAndReadLogs()
        {
            var serviceProvider = new ServiceProviderV2();

            var applicant1 = new ApplicantV2(serviceProvider.ContractAddress);
            var applicant2 = new ApplicantV2(serviceProvider.ContractAddress);
            var applicant3 = new ApplicantV2(serviceProvider.ContractAddress);
            var applicant4 = new ApplicantV2(serviceProvider.ContractAddress);

            await applicant1.SignUpAsync(PlanTier.Free);
            await applicant2.SignUpAsync(PlanTier.Premium);

            var log = await serviceProvider.GetAllRegistrationEventsAsync();

            Assert.Equal(2, log.Count);

            Assert.Equal(PlanTier.Free, log[0].Plan);
            Assert.Equal(PlanTier.Premium, log[1].Plan);

            log = await serviceProvider.GetPremiumRegistrationEventsAsync();

            Assert.Single(log);

            Assert.Equal(PlanTier.Premium, log[0].Plan);

            await applicant3.SignUpAsync(PlanTier.Standard);
            await applicant4.SignUpAsync(PlanTier.Premium);

            log = await serviceProvider.GetAllRegistrationEventsAsync();

            Assert.Equal(2, log.Count);

            Assert.Equal(PlanTier.Standard, log[0].Plan);
            Assert.Equal(PlanTier.Premium, log[1].Plan);

        }
    }
}
