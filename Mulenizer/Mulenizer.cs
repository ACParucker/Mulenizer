using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace ACParucker.Mulenizer
{
    class Mulenizer
    {
        private string ConfigFilename = "";
        private string BaseDirectory = "";
        private IDictionary<string, string> extensionFolder;

        public Mulenizer()
        {
        }

        public void LoadConfiguration()
        {
            this.extensionFolder = new Dictionary<string, string>();


            NameValueCollection configLines = ConfigurationManager.AppSettings;

            foreach (string key in configLines.AllKeys)
            {
                if (key == "BaseDirectory")
                {
                    this.BaseDirectory = configLines.Get(key);
                    continue;
                }

                string[] extensions = configLines.Get(key).Split(';');
                foreach (string ext in extensions)
                {
                    this.extensionFolder.Add(ext, key);
                }
            }
        }

        public void HeeHaw()
        {
            foreach(var extFol in this.extensionFolder)
            {
                string filter = "*." + extFol.Key;
                string dir = Path.Combine(this.BaseDirectory, extFol.Value);

                foreach(string file in Directory.EnumerateFiles(this.BaseDirectory, filter))
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    string dest = Path.Combine(dir, Path.GetFileName(file));

                    File.Move(file, dest);
                }
            }
        }
    }
}


