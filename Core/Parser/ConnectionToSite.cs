using System.Net.Http;

namespace Parser_for_AutoAll.Core.Parser
{
    class ConnectionToSite
    {
        private readonly NetworkParamaters networkParams = new();
        public string Connect()
        {
            HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.GZip };

            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Add(networkParams.clientHeaderAgent, networkParams.clientHeaderApp);

            var response = client.GetAsync(networkParams.url).Result;

            var html = response.Content.ReadAsStringAsync().Result;

            return html;
        }
    }
}
