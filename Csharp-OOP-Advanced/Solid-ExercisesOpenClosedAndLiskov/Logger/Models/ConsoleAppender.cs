using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models
{
    class ConsoleAppender:IAppender
    {
        public ConsoleAppender(ILayout layout,ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ErrorLevel Level { get; }

        public ILayout Layout { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            Console.WriteLine(this.Layout.FormatError(error));
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}";
        }
    }
}
