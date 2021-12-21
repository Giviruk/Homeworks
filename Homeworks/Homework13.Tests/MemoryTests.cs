using System.Text;
using JetBrains.dotMemoryUnit;
using Xunit;
using Xunit.Abstractions;

namespace Homework13.Tests
{
    public class MemoryTests : IClassFixture<HostBuilder>
    {
        private readonly WebTestHelper testHelper;
        private readonly ITestOutputHelper output;
        public MemoryTests(HostBuilder fixture, ITestOutputHelper output)
        {
            this.output = output;
            var client = fixture.CreateClient();
            testHelper = new WebTestHelper(client);
            DotMemoryUnitTestOutput.SetOutputMethod(this.output.WriteLine);
        }
        
        [Theory]
        [InlineData("+")]
        [DotMemoryUnit(CollectAllocations = true)]
        public void TestMemoryAsync(string operation)
        {
            var memoryPoint = dotMemory.Check();
            long size = 0;
            for (var i = 0; i < 10000000; i++)
            {
                var expression = $"{i}{operation}{i}";
                testHelper.GetResultAsync(expression).GetAwaiter().GetResult();
                size += Encoding.UTF8.GetBytes(expression).Length;
            }
            
            dotMemory.Check(
                memory =>
                {
                    var allocatedMemory = memory.GetTrafficFrom(memoryPoint).AllocatedMemory.SizeInBytes;
                    output.WriteLine(size.ToString());
                    output.WriteLine(allocatedMemory.ToString());
                    Assert.True(allocatedMemory > size);
                });
        }
    }
}