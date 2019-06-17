using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public async Task SmokeTestHomePage()
        {
            var webAppUrl = TestContext.Parameters["WebAppUrl"];
            Console.WriteLine($"a: {webAppUrl == null}");
            var client = new HttpClient();

            var result = await client.GetAsync(webAppUrl);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}