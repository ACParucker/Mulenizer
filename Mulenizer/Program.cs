using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace ACParucker.Mulenizer
{
    internal static class Program
    {
        private static IDictionary<string, string> extensionFolder;
        private static string BaseDirectory = "";


        private static void Main(string[] args)
        {
            LoadConfiguration();
            HeeHaw();
        }

        public static void LoadConfiguration()
        {
            extensionFolder = new Dictionary<string, string>();

            NameValueCollection configLines = ConfigurationManager.AppSettings;

            foreach (string key in configLines.AllKeys)
            {
                if (key == "BaseDirectory")
                {
                    BaseDirectory = configLines.Get(key);
                    continue;
                }

                string[] extensions = configLines.Get(key).Split(';');
                foreach (string ext in extensions)
                {
                    if (string.IsNullOrEmpty(ext))
                    {
                        continue;
                    }
                    extensionFolder.Add(ext, key);
                }
            }
        }

        public static void HeeHaw()
        {
            foreach (var extFol in extensionFolder)
            {
                System.Console.WriteLine($"Movendo {extFol.Key}...");
                string filter = "*." + extFol.Key;
                string dir = Path.Combine(BaseDirectory, extFol.Value);

                foreach (string file in Directory.EnumerateFiles(BaseDirectory, filter))
                {
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    string dest = Path.Combine(dir, Path.GetFileName(file));

                    File.Move(file, dest);
                }
            }
        }
    }
}
