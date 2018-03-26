using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;
        

        public FileAppender(ILayout layout, ErrorLevel parsedErrorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = parsedErrorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ErrorLevel Level { get; }
        public ILayout Layout { get; }
        public int MessagesAppended { get; private set; }
        public void Append(IError error)
        {
            string formatedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formatedError);
            MessagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
        }
    }
}