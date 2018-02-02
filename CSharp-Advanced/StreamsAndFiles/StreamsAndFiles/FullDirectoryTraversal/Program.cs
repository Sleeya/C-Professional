using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();

            List<string> directories = GetAllDirectories(path);

            var directoryFiles = new List<string>();

            foreach (var dir in directories)
            {
                
                directoryFiles.AddRange(Directory.GetFiles(dir));
            }

            foreach (var file in directoryFiles)
            {
                var fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                string fileExtension = fileInfo.Extension.Substring(1);

                if (!files.ContainsKey(fileExtension))
                {
                    files.Add(fileExtension, new List<string>());
                    files[fileExtension].Add($"--{fileName} - {(double)fileInfo.Length / 1000}kb");
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
        private static List<string> GetAllDirectories(string path)
        {
            var allDirectories = new List<string>();

            var directories = Directory.GetDirectories(path);

            foreach (var dir in directories)
            {
                allDirectories.AddRange(GetAllDirectories(dir));
            }
            allDirectories.Add(path);

            return allDirectories;
        }
    }
}
