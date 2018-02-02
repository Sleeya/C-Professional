using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();

            var directoryFiles = Directory.GetFiles(path);

            foreach (var file in directoryFiles)
            {
                var fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                string fileExtension = fileInfo.Extension.Substring(1);

                if (!files.ContainsKey(fileExtension))
                {
                    files.Add(fileExtension, new List<string>());
                    files[fileExtension].Add($"--{fileName} - {(double)fileInfo.Length / 1024}kb");
                }
                else
                {
                    files[fileExtension].Add($"--{fileName} - {(double)fileInfo.Length / 1000}kb");
                }

            }

            files.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "//report.txt";
            using (StreamWriter writer = new StreamWriter(desktop))
            {
                foreach (var file in files.OrderBy(x => x.Key))
                {
                    writer.WriteLine($".{file.Key}");
                    foreach (var name in file.Value)
                    {
                        writer.WriteLine(name);
                    }
                }
            }


        }


    }
}
