using System.Net.Http;

namespace Parser_for_AutoAll.Core.Parser
{
    class ConnectionToSite
    {
        public readonly string url = "https://www.avtoall.ru/bmw/";
        public readonly string clientHeaderAgent = "User-Agent";
        public readonly string clientHeaderApp = "C# App";
        public string Connect()
        {
            HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.GZip };

            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Add(clientHeaderAgent, clientHeaderApp);

            var response = client.GetAsync(url).Result;

            var html = response.Content.ReadAsStringAsync().Result;

            return html;
        }
    }
}
