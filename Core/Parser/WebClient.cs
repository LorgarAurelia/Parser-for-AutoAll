using System.Net.Http;

namespace Parser_for_AutoAll.Core.Parser
{
    class WebClient
    {
        private readonly string url = "https://www.avtoall.ru/bmw/";
        public string ConnectionToSite()
        {
            HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.GZip };

            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Add("User-Agent", "C# App");

            var response = client.GetAsync(url).Result;

            var html = response.Content.ReadAsStringAsync().Result;

            return html;
        }
    }
}
