using System;
using BenchmarkDotNet.Running;

namespace Homework13.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MethodsBenchmark>();
        }
    }
}