pragma solidity 0.4.23;

import "./Owned.sol";

contract EnrollmentV1 is Owned {

    enum PlanTier { Free, Standard, Premium }
    
    struct Applicant {
        address accountAddress;
        PlanTier plan;
    }

    mapping(address => Applicant) public applicants;

    function signUp(PlanTier plan) public {
        applicants[msg.sender] = Applicant(msg.sender, plan);
    }
}