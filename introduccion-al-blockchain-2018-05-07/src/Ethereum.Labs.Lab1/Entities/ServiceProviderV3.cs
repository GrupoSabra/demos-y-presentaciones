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
    public class ServiceProviderV3 : ServiceProviderV2
    {
        public override string ContractABI => Contracts.Instance.EnrollmentV3ABI;
        public override string ContractBIN => Contracts.Instance.EnrollmentV3BIN;

        public new async Task<List<RegistrationRequestedEventV3>> GetAllRegistrationEventsAsync()
        {
            return (await _registrationRequestedEvent.GetFilterChanges<RegistrationRequestedEventV3>(_allRegistrationsFilter))
                .Select(x => x.Event).ToList();
        }

        public new async Task<List<RegistrationRequestedEventV3>> GetPremiumRegistrationEventsAsync()
        {
            return (await _registrationRequestedEvent.GetFilterChanges<RegistrationRequestedEventV3>(_premiumRegistrationsFilter))
                .Select(x => x.Event).ToList();
        }
    }
}
