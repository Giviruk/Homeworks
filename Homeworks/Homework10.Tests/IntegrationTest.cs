using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Homework10.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;

namespace Homework10.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureServices(x =>
                    x.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("app")))
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class ProgramTests : IClassFixture<HostBuilder>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly HttpClient client;

        public ProgramTests(HostBuilder fixture, ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            client = fixture.CreateClient();
        }

        private async Task<string> GetResultAsync(string expression)
        {
            var response =
                await client.GetAsync($"http://localhost:5000/Calculator/Calculate?expression={expression}");
            return await response.Content.ReadAsStringAsync();
        }

        private async Task CheckResultAsync(string expression, string expected)
        {
            var result = await GetResultAsync(expression);
            Assert.Equal(expected, result);
        }

        private async Task<long> MeasureTimeAsync(string expression)
        {
            var st = new Stopwatch();
            st.Start();
            await GetResultAsync(expression);
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
            await CheckResultAsync(expression, expected);
        }
    }
}