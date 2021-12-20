using System;

namespace Homework13.Profiling
{
using System;
using System.Reflection;

namespace Homework13FirstTask
{
    class Program
    {
        private static readonly MethodInfo MethodFromTest = typeof(Test).GetMethod("ReflectionMethod");

        static void Main(string[] args)
        {
            var num = "10";
            var test = new Test();

            StartTest(() => test.SimpleMethod(num));
            StartTest(() => test.VirtualMethod(num));
            StartTest(() => Test.StaticMethod(num));
            StartTest(() => test.DynamicMethod(num));
            StartTest(() => test.GenericMethod<int>(num));
            StartTest(() => MethodFromTest.Invoke(test, new object[] {num}));
        }

        private static void StartTest(Action action)
        {
            for (var i = 0; i < 10000000; i++)
                action();
        }
    }

    class Test
    {
        public string SimpleMethod(string num)
        {
            for (int i = 0; i < 1; i++)
            {
                num += i;
            }

            return num;
        }

        public virtual string VirtualMethod(string num)
        {
            for (int i = 0; i < 1; i++)
            {
                num += i;
            }

            return num;
        }

        public static string StaticMethod(string num)
        {
            for (var i = 0; i < 1; i++)
            {
                num += i;
            }

            return num;
        }

        public T GenericMethod<T>(string num)
        {
            for (var i = 0; i < 1; i++)
            {
                num += i;
            }

            return default;
        }

        public string DynamicMethod(dynamic num)
        {
            for (var i = 0; i < 1; i++)
            {
                num += i.ToString();
            }

            return num;
        }

        public string ReflectionMethod(string num)
        {
            for (var i = 0; i < 1; i++)
            {
                num += i;
            }

            return num;
        }
    }
}
}