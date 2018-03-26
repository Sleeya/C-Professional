using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender GenerateAppender(string appenderType, string errorLevel, string layoutType)
        {
            ILayout layout = layoutFactory.GenerateLayout(layoutType);
            ErrorLevel parsedErrorLevel = this.ParseErrorLevel(errorLevel);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, parsedErrorLevel);
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName,this.fileNumber));
                    return new FileAppender(layout, parsedErrorLevel,logFile);
                default:
                    throw new ArgumentException($"Invalid Appender Type!");
            }
        }

        private ErrorLevel ParseErrorLevel(string errorLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), errorLevel);
                return (ErrorLevel) levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Invalid ErrorLevel Type!", e);
            }

        }
    }
}
