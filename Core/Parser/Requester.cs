using System.Net;
using System.Net.Http;
using System;

namespace Parser_for_AutoAll.Core.Parser
{
    class Requester
    {
        public static string PageLoader(string link)
        {
            using WebClient webClient = new();
            webClient.Headers.Add(NetworkParamaters.clientHeaderAgent, NetworkParamaters.clientHeaderApp);
            return webClient.DownloadString(link);
        }

        public static string PictureLoader(string unickName, string link, string path) 
        {
            string fileName;
            using WebClient loadClient = new();
            try
            {
                fileName = path + $"\\{unickName}.jpg";
                loadClient.DownloadFile(link, fileName);
                return fileName;
            }
            catch (Exception)
            {
                return "no photo";
            }
        }
    }
}
