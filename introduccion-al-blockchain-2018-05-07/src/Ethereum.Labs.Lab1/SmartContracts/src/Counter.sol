pragma solidity 0.4.23;

import "./Owned.sol";

contract Counter is Owned {

    uint32 private _count;

    function increment() public onlyOwner {
        _count++;
    }

    function getCount() public view returns (uint32) {
        return _count;
    }
}