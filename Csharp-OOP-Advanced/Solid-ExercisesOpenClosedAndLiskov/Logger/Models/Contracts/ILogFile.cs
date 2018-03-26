using System.Text;

namespace Logger.Models.Contracts
{
    public interface ILogFile
    {
        string Path { get; }

        void WriteToFile(string errorLog);

        int Size { get; }

       

    }
}
