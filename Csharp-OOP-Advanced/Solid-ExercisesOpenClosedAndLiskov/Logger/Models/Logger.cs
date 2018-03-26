using System.Collections.Generic;
using Logger.Models.Contracts;

namespace Logger.Models.Loggers
{
    public class Logger:ILogger
    {
        IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level <= error.Level )
                {
                    appender.Append(error);
                }
            }
        }
    }
}
