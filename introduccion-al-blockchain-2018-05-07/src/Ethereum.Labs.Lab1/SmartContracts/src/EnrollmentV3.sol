pragma solidity 0.4.23;

import "./Owned.sol";

contract EnrollmentV3 is Owned {

    enum PlanTier { Free, Standard, Premium }
    
    struct Applicant {
        bool valid;
        address accountAddress;
        PlanTier plan;
        uint256 payment;
    }

    event RegistrationRequested(PlanTier indexed plan, address sender, uint256 payment);

    mapping(address => Applicant) public applicants;

    function signUp(PlanTier plan) public payable {
        if (applicants[msg.sender].valid) {
            revert();
        }

        if (plan == PlanTier.Free && msg.value != 0) {
            revert();
        }

        if (plan == PlanTier.Standard && msg.value != 100) {
            revert();
        }

        if (plan == PlanTier.Premium && msg.value != 200) {
            revert();
        }

        applicants[msg.sender] = Applicant(true, msg.sender, plan, msg.value);
        
        emit RegistrationRequested(plan, msg.sender, msg.value);
    }
}