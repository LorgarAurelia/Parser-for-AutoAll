using System;
using System.IO;

namespace Parser_for_AutoAll.Core.Parser
{
    class PictureLoader : DataSystemiser
    {
        readonly System.Net.WebClient client = new();
        readonly DataSystemiser systemData = new();
        private string emptyPicture = "no photo";

        public void Loader() 
        {
            systemData.Sytemiser();
            var networkParams = new WebClient();
            string fileName;
            string path = @"c:\picture";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int counter = 0; counter < systemData.data.PictureLink.Count; counter++)
            {
                if (systemData.data.PictureLink[counter] != "/pic/no_photo_150.jpg")
                {
                    client.Headers.Add(networkParams.clientHeaderAgent, networkParams.clientHeaderApp);
                    fileName = path + @"\" +Convert.ToString(counter) + ".jpg";
                    client.DownloadFile(systemData.data.PictureLink[counter], fileName);
                    systemData.data.PathToSavedPicture.Add(fileName);
                } else if(systemData.data.PictureLink[counter] == "/pic/no_photo_150.jpg")
                    systemData.data.PathToSavedPicture.Add(emptyPicture);
            }
        }
    }
}
