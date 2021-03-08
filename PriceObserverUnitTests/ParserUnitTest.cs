using System;
using System.Net.Http;
using Xunit;

namespace PriceObserverUnitTests
{
    public class ParserUnitTest
    {
        protected async System.Threading.Tasks.Task<string> GetHtmlAsync(string url)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
