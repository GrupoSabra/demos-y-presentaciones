using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using Ethereum.Labs.Common;

namespace Ethereum.Labs.Lab1.SmartContracts
{
    public class Contracts
    {
        private static readonly Lazy<Contracts> _instance = new Lazy<Contracts>(() => new Contracts(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static Contracts Instance => _instance.Value;

        public string CounterABI =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.Counter.abi");

        public string CounterBIN =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.Counter.bin");

        public string EnrollmentV1ABI =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV1.abi");

        public string EnrollmentV1BIN =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV1.bin");

        public string EnrollmentV2ABI =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV2.abi");

        public string EnrollmentV2BIN =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV2.bin");

        public string EnrollmentV3ABI =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV3.abi");

        public string EnrollmentV3BIN =>
            typeof(Contracts).Assembly.GetResourceString("Ethereum.Labs.Lab1.SmartContracts.src.bin.EnrollmentV3.bin");

        private Contracts() { }
    }
}
