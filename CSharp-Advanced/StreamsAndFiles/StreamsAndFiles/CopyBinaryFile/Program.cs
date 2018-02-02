using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readFile = new FileStream("copyMe.png",FileMode.Open))
            {
                using (FileStream writeFile = new FileStream("youGotCopied.png",FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {

                        int readBytes = readFile.Read(buffer, 0, buffer.Length);
                        if (readBytes <= 0)
                        {
                            break;
                        }
                        writeFile.Write(buffer,0,readBytes);
                    }
                }
            }
        }
    }
}
