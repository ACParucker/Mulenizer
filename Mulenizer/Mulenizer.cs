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
            /*this.ConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mulenizer.conf");

            FileInfo ConfigFileInfo = new FileInfo(this.ConfigFilename);

            if (!ConfigFileInfo.Exists)
            {
                System.Console.WriteLine("mulenizer.conf not found.");
                Environment.Exit(-1);
            }

            if (ConfigFileInfo.Length == 0)
            {
                System.Console.WriteLine("mulenizer.conf is empty.");
                Environment.Exit(-1);
            }
            */
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

            }
        }
    }
}


