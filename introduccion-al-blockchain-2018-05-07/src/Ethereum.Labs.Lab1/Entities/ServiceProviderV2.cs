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
    public class ServiceProviderV2 : ServiceProviderV1
    {
        protected readonly Event _registrationRequestedEvent;
        protected readonly HexBigInteger _allRegistrationsFilter;
        protected readonly HexBigInteger _premiumRegistrationsFilter;

        public ServiceProviderV2()
        {
            _registrationRequestedEvent = _enrollmentContract.GetEvent("RegistrationRequested");

            _allRegistrationsFilter = _registrationRequestedEvent.CreateFilterAsync().Result;
            _premiumRegistrationsFilter = _registrationRequestedEvent.CreateFilterAsync((byte)PlanTier.Premium).Result;
        }

        public override string ContractABI => Contracts.Instance.EnrollmentV2ABI;
        public override string ContractBIN => Contracts.Instance.EnrollmentV2BIN;

        public async Task<List<RegistrationRequestedEventV1>> GetAllRegistrationEventsAsync()
        {
            return (await _registrationRequestedEvent.GetFilterChanges<RegistrationRequestedEventV1>(_allRegistrationsFilter))
                .Select(x => x.Event).ToList();
        }

        public async Task<List<RegistrationRequestedEventV1>> GetPremiumRegistrationEventsAsync()
        {
            return (await _registrationRequestedEvent.GetFilterChanges<RegistrationRequestedEventV1>(_premiumRegistrationsFilter))
                .Select(x => x.Event).ToList();
        }
    }
}
