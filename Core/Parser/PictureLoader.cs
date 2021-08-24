using System;
using System.IO;

namespace Parser_for_AutoAll.Core.Parser
{
    class PictureLoader 
    {
        readonly System.Net.WebClient client = new();
        public HtmlParser parsedData = new();
        private readonly string emptyPicture = "no photo";

        public void Loader() 
        {
            parsedData.ParseHtml();
            NetworkParamaters networkParams = new();
            string fileName;
            string path = @"c:\picture";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int counter = 0; counter < parsedData.savedData.PictureLink.Count; counter++)
            {
                if (parsedData.savedData.PictureLink[counter] != "/pic/no_photo_150.jpg")
                {
                    client.Headers.Add(networkParams.clientHeaderAgent, networkParams.clientHeaderApp);
                    fileName = path + @"\" +Convert.ToString(counter) + ".jpg";
                    client.DownloadFile(parsedData.savedData.PictureLink[counter], fileName);
                    parsedData.savedData.PathToSavedPicture.Add(fileName);
                } else if(parsedData.savedData.PictureLink[counter] == "/pic/no_photo_150.jpg")
                    parsedData.savedData.PathToSavedPicture.Add(emptyPicture);
            }
        }
    }
}
