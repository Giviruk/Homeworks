using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace Homework13.Benchmarks
{
    [MemoryDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    public class MethodsBenchmark
    {
        private Test test;
        private string testNumber;
        private static MethodInfo methodFromTest;
        [GlobalSetup]
        public void Setup()
        {
            test = new Test();
            methodFromTest = typeof(Test).GetMethod("ReflectionMethod");
            testNumber = "10";
        }

        [Benchmark(Description = "simple method")]
        public void TestSimpleMethod()
        { 
            test.SimpleMethod(testNumber);
        }
        [Benchmark(Description = "static method")]
        public void TestStaticMethod()
        {
            Test.StaticMethod(testNumber);
        }
        [Benchmark(Description = "virtual method")]
        public void TestVirtualMethod()
        {
            test.VirtualMethod(testNumber);
        }
        [Benchmark(Description = "generic method")]
        public void TestGenericMethod()
        {
            test.GenericMethod<string>(testNumber);
        }
        [Benchmark(Description = "reflection method")]
        public void TestReflectionMethod()
        {
            methodFromTest.Invoke(test, new object[] { testNumber });
        }
        [Benchmark(Description = "dynamic method")]
        public void TestDynamicMethod()
        {
            test.DynamicMethod(testNumber);
        }
    }
    class Test
    {
        public string SimpleMethod(string num)
        {
            num += num;
            return num;
        }

        public virtual string VirtualMethod(string num)
        {
            num += num;
            return num;
        }

        public static string StaticMethod(string num)
        {
            num += num;
            return num;
        }

        public string GenericMethod<T>(T num)
        {
            return num.ToString() + num;
        }

        public string DynamicMethod(dynamic num)
        {
            num += num.ToString();
            return num;
        }

        public string ReflectionMethod(string num)
        {
            num += num;
            return num;
        }
    }
}