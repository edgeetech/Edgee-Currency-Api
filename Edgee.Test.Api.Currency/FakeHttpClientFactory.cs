using System.Net.Http;

namespace Edgee.Test.Api.Currency
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient();
        }
    }
}
