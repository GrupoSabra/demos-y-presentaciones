pragma solidity 0.4.23;

contract Owned {
    address private _owner;

    constructor() public {
        _owner = msg.sender;
    }

    modifier onlyOwner {
        require(msg.sender == _owner);
        _;
    }
}