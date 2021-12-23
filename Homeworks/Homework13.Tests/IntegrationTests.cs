using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Homework13.WebCalculator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Homework13.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class ProgramTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient client;
        private readonly WebTestHelper testHelper;
        public ProgramTests(HostBuilder fixture)
        {
            client = fixture.CreateClient();
            testHelper = new WebTestHelper(client);
        }

        private async Task<long> MeasureTimeAsync(string expression)
        {
            var st = new Stopwatch();
            st.Start();
            await testHelper.GetResultAsync(expression);
            st.Stop();
            return st.ElapsedMilliseconds;
        }

        [Theory]
        [InlineData("220+8", "228")]
        [InlineData("2+2*2", "6")]
        [InlineData("1+2+3+4+5", "15")]
        [InlineData("1*2*3*4*5", "120")]
        public async Task Program_CorrectValues_CorrectResultReturned(string expression, string expected)
        {
            await testHelper.CheckResultAsync(expression, expected);
        }
    }
}