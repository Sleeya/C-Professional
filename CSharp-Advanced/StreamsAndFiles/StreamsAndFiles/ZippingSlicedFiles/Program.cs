using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {

            string sourceFile = "../resources/sliceMe.mp4";
            string destinationDirectory = "";
            int parts = 5;

            Zip(sourceFile, destinationDirectory, parts);
            string extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);
            List<string> files = new List<string>();
            for (int i = 0; i < parts; i++)
            {
                files.Add("Part-" + i +"." + extension + ".gz" );
            }

            Assemble(files, destinationDirectory);


        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partsSize = (long)Math.Ceiling((double)reader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);

                for (int slice = 0; slice < parts; slice++)
                {
                    int currentPieceSize = 0;
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = "Part-" + slice + "." + extension+".gz";

                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create),CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytes);
                            currentPieceSize += buffer.Length;
                            if (currentPieceSize >= partsSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }

        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf(".") -3,3);
            using (FileStream writer = new FileStream($"{destinationDirectory}assembled.{extension}", FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (GZipStream reader = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {

                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes <= 0)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
