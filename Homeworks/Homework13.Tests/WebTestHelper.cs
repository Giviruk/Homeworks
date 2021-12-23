using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Homework13.Tests
{
    public class WebTestHelper
    {
        private readonly HttpClient client;

        public WebTestHelper(HttpClient client)
        {
            this.client = client;
        }
        public async Task<string> GetResultAsync(string expression)
        {
            var response =
                await client.GetAsync($"http://localhost:5000/CalculatorCache/Calculate?expression={expression}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task CheckResultAsync(string expression, string expected)
        {
            var result = await GetResultAsync(expression);
            Assert.Equal(expected, result);
        }
    }
}