using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Labs.Lab1.Entities;
using Xunit;

namespace Ethereum.Labs.Lab1
{
    public class ComplexTypesAndMappingsTests
    {
        [Fact]
        public async Task UseMappingsAndRetrieveAComplexType()
        {
            var serviceProvider = new ServiceProviderV1();

            var applicant1 = new ApplicantV1(serviceProvider.ContractAddress);
            var applicant2 = new ApplicantV1(serviceProvider.ContractAddress);

            // This call is sending one parameter to the function
            await applicant1.SignUpAsync(PlanTier.Free);
            await applicant2.SignUpAsync(PlanTier.Premium);

            // This call is mapping the struct from solidity to C#
            var status = await applicant1.GetStatusAsync();

            Assert.Equal(applicant1.Account.Address, status.AccountAddress, true);
            Assert.Equal(PlanTier.Free, status.Plan);

            status = await applicant2.GetStatusAsync();

            Assert.Equal(applicant2.Account.Address, status.AccountAddress, true);
            Assert.Equal(PlanTier.Premium, status.Plan);
        }
    }
}
