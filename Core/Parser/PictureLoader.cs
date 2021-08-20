using System;
using System.IO;

namespace Parser_for_AutoAll.Core.Parser
{
    class PictureLoader : DataSystemiser
    {
        System.Net.WebClient client = new();
        DataSystemiser systemData = new();

        public void Loader() 
        {
            systemData.Sytemiser();

            string fileName;
            string path = @"c:\picture";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int counter = 0; counter < systemData.data.pictureLink.Count; counter++)
            {
                if (systemData.data.pictureLink[counter] != "/pic/no_photo_150.jpg")
                {
                    client.Headers.Add("User-Agent", "C# App");
                    fileName = path + @"\" +Convert.ToString(counter) + ".jpg";
                    client.DownloadFile(systemData.data.pictureLink[counter], fileName);
                }
            }
        }
    }
}
