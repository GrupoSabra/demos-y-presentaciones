pragma solidity 0.4.23;

import "./Owned.sol";

contract EnrollmentV2 is Owned {

    enum PlanTier { Free, Standard, Premium }
    
    struct Applicant {
        address accountAddress;
        PlanTier plan;
    }

    event RegistrationRequested(PlanTier indexed plan, address sender);

    mapping(address => Applicant) public applicants;

    function signUp(PlanTier plan) public {
        applicants[msg.sender] = Applicant(msg.sender, plan);
        emit RegistrationRequested(plan, msg.sender);
    }
}